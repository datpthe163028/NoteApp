using System;
using System.Collections.Generic;

namespace NoteApp.App.Database.Data
{
    public partial class ToDoListNote
    {
        public int ToDoListNoteId { get; set; }
        public bool? Status { get; set; }
        public string? Task { get; set; }
        public DateTime? Due { get; set; }

        public virtual Filenote ToDoListNoteNavigation { get; set; } = null!;
    }
}
