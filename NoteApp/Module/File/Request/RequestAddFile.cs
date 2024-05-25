namespace NoteApp.Module.File.Request
{
    public class RequestAddFile
    {
        public string FileName { get; set; }
        public int FolderId { get; set; }
        public string typeFile { get; set; }
    }

    public class RequestUpdateSimpleFile
    {
        public int SimpleNoteId { get; set; }
        public string content { get; set; }
    }
}
