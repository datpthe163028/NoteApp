using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NoteApp.App.Database.Data
{
    public partial class Filenote
    {
        public int FileId { get; set; }
        public string? FileName { get; set; }
        public string? Filetype { get; set; }
        public int? FolderId { get; set; }
        [JsonIgnore]

        public virtual Foldernote? Folder { get; set; }
        [JsonIgnore]
        public virtual SimpleNote? SimpleNote { get; set; }
        [JsonIgnore]
        public virtual ToDoListNote? ToDoListNote { get; set; }
        public virtual ICollection<ComplextNote> ComplexNotes { get; set; }
    }
}
