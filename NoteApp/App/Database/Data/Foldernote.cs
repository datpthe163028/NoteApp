using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NoteApp.App.Database.Data
{
    public partial class Foldernote
    {
        public Foldernote()
        {
            Filenotes = new HashSet<Filenote>();
        }

        public int FolderId { get; set; }
        public string? FolderName { get; set; }
        public int? UserId { get; set; }
        [JsonIgnore]
        public virtual User? User { get; set; }
        [JsonIgnore]
        public virtual ICollection<Filenote> Filenotes { get; set; }
    }
}
