using System.IO;

namespace NoteApp.App.Database.Data
{
    public class ComplextNote
    {
        public int ComplexNoteId { get; set; }
        public string Header1 { get; set; }
        public string Content1 { get; set; }
        public string Header2 { get; set; }
        public string Content2 { get; set; }
        public string Header3 { get; set; }
        public string Content3 { get; set; }
        // Foreign Key to FileNote
        public int FileNoteId { get; set; }

        // Navigation property
        public virtual Filenote FileNote { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }

    public class Document
    {
        public int DocumentId { get; set; }
        public string Header {  get; set; }
        public string Content { get; set; }

        public int ComplextNoteId { get; set; }
        public virtual ComplextNote ComplextNote { get; set; }


    }
}
