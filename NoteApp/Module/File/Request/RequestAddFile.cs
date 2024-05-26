using NoteApp.App.Database.Data;

namespace NoteApp.Module.File.Request
{
    public class RequestAddFile
    {
        public string FileName { get; set; }
        public int FolderId { get; set; }
        public string typeFile { get; set; }
    }


    public class RequestUpdateToDoList
    {
        public int DetailToDoListId { get; set; }
        public bool Status { get; set; }
        public string? TaskName { get; set; }
        public DateTime? Due { get; set; }
        public int? ToDoListNoteId { get; set; }
       
    }

    public class RequestAddToDoList
    {
        public bool Status { get; set; }
        public string? TaskName { get; set; }
        public DateTime? Due { get; set; }
        public int? ToDoListNoteId { get; set; }

    }
}
