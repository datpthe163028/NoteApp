using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualBasic.FileIO;
using NoteApp.App.Database.Data;
using NoteApp.App.DesignPatterns.Factory;
using System.Xml.Linq;
namespace NoteApp.App.DesignPatterns.Strategy
{
    public interface OperateFileStrategy
    {
        Task<Filenote> CreateFile(string fileName, int folderId);
    }

    public class OperateSimpleFileNoteStrategy : OperateFileStrategy
    {

        public async Task<Filenote> CreateFile(string fileName, int folderId)
        {
            noteappContext ct = new noteappContext();
            var file = new Filenote() { FileName = fileName, FolderId = folderId };
            ct.Filenotes.Add(file);
            await ct.SaveChangesAsync();
            ct.SimpleNotes.Add(new SimpleNote () { SimpleNoteId = file.FileId, Content = ""} );
            await ct.SaveChangesAsync();
            return file;
        }
    }

    public class OperateToDoListFileNoteStrategy : OperateFileStrategy
    {
        public async Task<Filenote> CreateFile(string fileName, int folderId)
        {
            noteappContext ct = new noteappContext();
            var file = new Filenote() { FileName = fileName, FolderId = folderId };
            ct.Filenotes.Add(file);
            await ct.SaveChangesAsync();
            ct.ToDoListNotes.Add(new ToDoListNote() {  });
            await ct.SaveChangesAsync();
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

        public Task<Filenote> AddFile(string fileName, int folderId)
        {
            if(_OperateFileStrategy != null) 
                return _OperateFileStrategy.CreateFile(fileName, folderId);
            return null;
        }
     

    }


}
