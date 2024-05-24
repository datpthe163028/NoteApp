using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using NoteApp.App.Database.Data;
using NoteApp.App.DesignPatterns.Repository;
using NoteApp.App.SignalR.Model;
using NoteApp.Data;
using System.Collections.Concurrent;

namespace NoteApp.App.SignalR
{
    public class ChatHub : Hub
    {
        private readonly UnitOfWork _unitOfWork;
        public ChatHub(UnitOfWork u)
        {
            _unitOfWork = u;
        }


        public override Task OnConnectedAsync()
        {
            string userId = Context.GetHttpContext().Request.Query["userId"];
            return base.OnConnectedAsync();
        }

        public async Task SendMessage(string user, string message)
        {
            //if (userConnections.TryGetValue(user, out string connectionId))
            //{
            //    if (user == "simplenote")
            //    {
            //        var note = JsonConvert.DeserializeObject<simpleNoteSignalR>(message);

            //        var x = _unitOfWork.SimpleNotes.FindByCondition(x => x.SimpleNoteId == note.Id).FirstOrDefault();
            //        if (!(note.content == "kh@iTao"))
            //        {

            //            await Clients.Client(connectionId).SendAsync("ReceiveMessage", user, note.content);
            //        }
            //        else
            //        {
            //            await Clients.Client(connectionId).SendAsync("ReceiveMessage", user, x.Content);
            //        }
            //    }
            //    else if (user == "todolistnote")
            //    {

            //    }
            //}

        }

    }
}
