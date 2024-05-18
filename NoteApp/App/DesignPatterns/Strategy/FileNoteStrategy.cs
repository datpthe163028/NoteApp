using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualBasic.FileIO;
using NoteApp.App.Database.Data;
using NoteApp.App.DesignPatterns.Factory;
using System.Xml.Linq;
namespace NoteApp.App.DesignPatterns.Strategy
{
    public interface OperateFileStrategy
    {
        Filenote CreateFile(string fileName, int folderId);
    }

    public class OperateSimpleFileNoteStrategy : OperateFileStrategy
    {

        public Filenote CreateFile(string fileName, int folderId)
        {
            noteappContext ct = new noteappContext();
            var file = new Filenote() { FileName = fileName, FolderId = folderId };
            ct.Filenotes.Add(file);
            ct.SaveChanges();
            ct.SimpleNotes.Add(new SimpleNote () { SimpleNoteId = file.FileId, Content = ""} );
            ct.SaveChanges();
            return file;
        }
    }

    public class OperateToDoListFileNoteStrategy : OperateFileStrategy
    {
        public Filenote CreateFile(string fileName, int folderId)
        {
            noteappContext ct = new noteappContext();
            var file = new Filenote() { FileName = fileName, FolderId = folderId };
            ct.Filenotes.Add(file);
            ct.SaveChanges();
            ct.ToDoListNotes.Add(new ToDoListNote() {  });
            return file;
        }
    }


    public class OperateFileStrategyFactory
    {
        public static OperateFileStrategy  CreateFileStrategy(string type)
        {
            switch (type)
            {
                case "SIMPLE":
                    return new OperateSimpleFileNoteStrategy();
                case "TODOLIST":
                    return new OperateToDoListFileNoteStrategy();
                default:
                    return null;
            }
        }
    }

    public class OperateNote
    {
        private  OperateFileStrategy? _OperateFileStrategy;

        public void SetFileStrategy(string type) {
            this._OperateFileStrategy = OperateFileStrategyFactory.CreateFileStrategy(type);
        }

        public Filenote AddFile(string fileName, int folderId)
        {
            if(_OperateFileStrategy != null) 
                return _OperateFileStrategy.CreateFile(fileName, folderId);
            return null;
        }
     

    }


}
