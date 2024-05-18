using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NoteApp.App.Database.Data
{
    public partial class ToDoListNote : IFile
    {
        public int ToDoListNoteId { get; set; }
        public string? Header { get; set; }
        [JsonIgnore]

        public virtual Filenote ToDoListNoteNavigation { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<DetailToDoList> DetailToDoLists { get; set; }
    }
}
