using System;
using System.Collections.Generic;

namespace NoteApp.Data
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

        public virtual User? User { get; set; }
        public virtual ICollection<Filenote> Filenotes { get; set; }
    }
}
