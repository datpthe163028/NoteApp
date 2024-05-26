using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using NoteApp.App.Database.Data;
using NoteApp.App.DesignPatterns.Repository;
using NoteApp.App.SignalR.Model;
using NoteApp.Data;
using System.Collections.Concurrent;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace NoteApp.App.SignalR
{
    public class ChatHub : Hub
    {
        private readonly UnitOfWork _unitOfWork;

        public ChatHub(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddToGroup(string fileId, string option)
        {

            int id;
            if (int.TryParse(fileId, out id))
            {
                if (option == "simplenote")

                {
                    var x = _unitOfWork.SimpleNotes.FindByCondition(x => x.SimpleNoteId == id).FirstOrDefault();
                    await Groups.AddToGroupAsync(Context.ConnectionId, fileId + "simple");
                    await Clients.Group(fileId + "simple").SendAsync("ReceiveMessage", x.Content);
                }
                else if (option == "todolist")
                {
                    await Groups.AddToGroupAsync(Context.ConnectionId, fileId + "todolist");
                    var x = _unitOfWork.ToDoListDetails.FindByCondition(x => x.ToDoListNoteId == id).ToList().Select(x => new { Status = x.Status, TaskName = x.TaskName, Due = x.Due });
                    await Clients.Group(fileId + "todolist").SendAsync("ReceiveMessage", JsonConvert.SerializeObject(x));
                }

            }
            else
            {
            }
        }
        public async Task SendMessage(string user, string message)
        {

            if (user == "simplenote")
            {

                try
                {
                    var note = JsonConvert.DeserializeObject<simpleNoteSignalR>(message);
                    await Clients.Group(note.Id + "simple").SendAsync("ReceiveMessage", note.content);
                    int id;
                    Int32.TryParse(note.Id, out id);
                    var x = _unitOfWork.SimpleNotes.FindByCondition(x => x.SimpleNoteId == id).FirstOrDefault();
                    x.Content = note.content;
                    _unitOfWork.SimpleNotes.Update(x);
                    await _unitOfWork.SaveChangesAsync();

                }
                catch
                {

                }

            }
            else if (user == "todolist")
            {
                try
                {
                    var note = JsonConvert.DeserializeObject<simpleNoteSignalRTodoList>(message);
                    await Clients.Group(note.Id + "simple").SendAsync("ReceiveMessage", note.content);
                    int id;
                    Int32.TryParse(note.Id, out id);
                    var x = _unitOfWork.ToDoListDetails.FindByCondition(x => x.ToDoListNoteId == id).ToList();
                    _unitOfWork.ToDoListDetails.RemoveRange(x);
                    _unitOfWork.ToDoListDetails.AddRange(note.content); 
                    await _unitOfWork.SaveChangesAsync();
                }
                catch
                {

                }
            }
        }
    }
}


