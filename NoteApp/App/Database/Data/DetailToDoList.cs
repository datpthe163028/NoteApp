using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NoteApp.App.Database.Data
{
    public partial class DetailToDoList
    {
        public int DetailToDoListId { get; set; }
        public bool Status { get; set; }
        public string? TaskName { get; set; }
        public DateTime? Due { get; set; }
        [JsonIgnore]
        public int? ToDoListNoteId { get; set; }
        [JsonIgnore]
        public virtual ToDoListNote? ToDoListNote { get; set; }
    }
}
