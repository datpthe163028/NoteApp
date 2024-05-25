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

        public async Task AddToGroup(string fileId)
        {
            int id;
            if (int.TryParse(fileId, out id))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, fileId);

                var x = _unitOfWork.SimpleNotes.FindByCondition(x => x.SimpleNoteId == id).FirstOrDefault();
                await Clients.Group(fileId).SendAsync("ReceiveMessage", x.Content);
            }
            else
            {
                
            }
        }

        public async Task SendMessage(string user, string message)
        {

            if (user == "simplenote")
            {
                var note = JsonConvert.DeserializeObject<simpleNoteSignalR>(message);
                await Clients.Group(note.Id).SendAsync("ReceiveMessage", note.content);

            }
            else if (user == "todolistnote")
            {

            }
        }

        public async Task End(string user, string message)
        {

            if (user == "simplenote")
            {
                var note = JsonConvert.DeserializeObject<simpleNoteSignalR>(message);
                await Clients.Group(note.Id).SendAsync("ReceiveMessage", note.content);

            }
            else if (user == "todolistnote")
            {

            }
        }
    }
}


