using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NoteApp.App.Database.Data
{
    public partial class SimpleNote : IFile
    {
        public int SimpleNoteId { get; set; }
        public string? Content { get; set; }
        [JsonIgnore]

        public virtual Filenote SimpleNoteNavigation { get; set; } = null!;
    }
}
