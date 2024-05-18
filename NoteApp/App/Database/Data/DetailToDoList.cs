using System;
using System.Collections.Generic;

namespace NoteApp.App.Database.Data
{
    public partial class DetailToDoList
    {
        public int DetailToDoListId { get; set; }
        public ulong? Status { get; set; }
        public string? TaskName { get; set; }
        public DateTime? Due { get; set; }
        public int? ToDoListNoteId { get; set; }

        public virtual ToDoListNote? ToDoListNote { get; set; }
    }
}
