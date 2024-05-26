using NoteApp.App.Database.Data;

namespace NoteApp.App.SignalR.Model
{
    public class simpleNoteSignalR
    {
        public string Id { get; set; }
        public string content { get; set; }
    }

    public class simpleNoteSignalRTodoList
    {
        public string Id { get; set; }
        public List<DetailToDoList> content { get; set; }
    }

}
