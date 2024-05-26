using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualBasic.FileIO;
using NoteApp.App.Database.Data;
using NoteApp.App.DesignPatterns.Factory;
using NoteApp.App.DesignPatterns.Repository;
using System.Xml.Linq;
namespace NoteApp.App.DesignPatterns.Strategy
{
    public interface OperateFileStrategy
    {
        Task<Filenote> CreateFile(string fileName, int folderId);
    }

    public class OperateSimpleFileNoteStrategy : OperateFileStrategy
    {
        private readonly UnitOfWork  _unitOfWork;
        public OperateSimpleFileNoteStrategy(UnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }


        public async Task<Filenote> CreateFile(string fileName, int folderId)
        {
           
            var file = new Filenote() { Filetype = "SIMPLE", FileName = fileName, FolderId = folderId };
            _unitOfWork.FileNotes.Add(file);
            await _unitOfWork.SaveChangesAsync();
            _unitOfWork.SimpleNotes.Add(new SimpleNote () { SimpleNoteId = file.FileId, Content = ""} );
            await _unitOfWork.SaveChangesAsync();
            return file;
        }
    }

    public class OperateToDoListFileNoteStrategy : OperateFileStrategy
    {

        private readonly UnitOfWork _unitOfWork;
        public OperateToDoListFileNoteStrategy(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Filenote> CreateFile(string fileName, int folderId)
        {
            var file = new Filenote() { Filetype = "TODOLIST", FileName = fileName, FolderId = folderId };
            _unitOfWork.FileNotes.Add(file);
            await _unitOfWork.SaveChangesAsync();
            _unitOfWork.ToDoListNotes.Add(new ToDoListNote() { ToDoListNoteId = file.FileId, Header = ""  });
            await _unitOfWork.SaveChangesAsync();
            return file;
        }
    }


    public class OperateFileStrategyFactory
    {
        private readonly OperateSimpleFileNoteStrategy _op1;
        private readonly OperateToDoListFileNoteStrategy _op2;

        public OperateFileStrategyFactory(OperateSimpleFileNoteStrategy op1, OperateToDoListFileNoteStrategy op2)
        {
            _op1 = op1;
            _op2 = op2;
        }

        public  OperateFileStrategy  CreateFileStrategy(string type)
        {
            switch (type)
            {
                case "SIMPLE":
                    return _op1;
                case "TODOLIST":
                    return _op2;
                default:
                    return null;
            }
        }
    }

    public class OperateNote
    {
        private  OperateFileStrategy? _OperateFileStrategy;
        private OperateFileStrategyFactory? _OperateFileStrategyFactory;

        public OperateNote(OperateFileStrategyFactory op) {
            _OperateFileStrategyFactory = op;
        }

        public void SetFileStrategy(string type) {
            this._OperateFileStrategy = _OperateFileStrategyFactory.CreateFileStrategy(type);
        }

        public Task<Filenote> AddFile(string fileName, int folderId)
        {
            if(_OperateFileStrategy != null) 
                return _OperateFileStrategy.CreateFile(fileName, folderId);
            return null;
        }
     

    }


}
