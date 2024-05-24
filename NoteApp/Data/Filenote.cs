using System;
using System.Collections.Generic;

namespace NoteApp.Data
{
    public partial class Filenote
    {
        public int FileId { get; set; }
        public string? FileName { get; set; }
        public int? FolderId { get; set; }
        public string? Filetype { get; set; }

        public virtual Foldernote? Folder { get; set; }
        public virtual SimpleNote? SimpleNote { get; set; }
        public virtual ToDoListNote? ToDoListNote { get; set; }
    }
}
