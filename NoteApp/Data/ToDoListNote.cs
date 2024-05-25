using System;
using System.Collections.Generic;

namespace NoteApp.Data
{
    public partial class ToDoListNote
    {
        public ToDoListNote()
        {
            DetailToDoLists = new HashSet<DetailToDoList>();
        }

        public int ToDoListNoteId { get; set; }
        public string? Header { get; set; }

        public virtual Filenote ToDoListNoteNavigation { get; set; } = null!;
        public virtual ICollection<DetailToDoList> DetailToDoLists { get; set; }
    }
}
