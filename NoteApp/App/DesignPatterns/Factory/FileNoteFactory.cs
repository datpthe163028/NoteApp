using NoteApp.App.Database.Data;
using NoteApp.App.DesignPatterns.Strategy;

namespace NoteApp.App.DesignPatterns.Factory
{

    public class FileNoteFactory
    {
        public static  IFile CreateFileNote(string FileNoteType)
        {
            switch (FileNoteType)
            {
                case "SIMPLE":
                    return new SimpleNote();
                case "TODOLIST":
                    return new ToDoListNote();
                default:
                    throw new ArgumentException("Unknown animal type");
            }
        }
    }
}
