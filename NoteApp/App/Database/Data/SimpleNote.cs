using System;
using System.Collections.Generic;

namespace NoteApp.App.Database.Data
{
    public partial class SimpleNote
    {
        public int SimpleNoteId { get; set; }
        public string? Content { get; set; }

        public virtual Filenote SimpleNoteNavigation { get; set; } = null!;
    }
}
