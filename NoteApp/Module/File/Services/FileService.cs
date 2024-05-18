using Microsoft.EntityFrameworkCore;
using NoteApp.App.Database.Data;
using NoteApp.App.DesignPatterns.Strategy;
using NoteApp.Module.Folder.Services;

namespace NoteApp.Module.File.Services
{
    public interface IFileService
    {
        Task<(Filenote? data, string ErrorMessage)> CreateFile(int folderId, string filename, string typeFile);
        (List<Filenote> Filenote, string message) GetList(int folderId);
    }
    public class FileService : IFileService
    {
        private readonly UnitOfWork unitOfWork;
        public FileService(UnitOfWork uno)
        {
            unitOfWork = uno;
        }
        public (List<Filenote> Filenote, string message) GetList(int folderId)
        {
            var x = unitOfWork.FolderNotes.FindByCondition(s => s.FolderId == folderId).Include(s => s.Filenotes).FirstOrDefault();
            if (x == null)
                return (null, "folder not found");

            return (x.Filenotes.ToList(), "");
        }

        public async Task<(Filenote? data, string ErrorMessage)> CreateFile(int folderId,string fileName, string typeFile)
        {
            if(string.IsNullOrEmpty(fileName))
                return (null, "error");

            OperateNote operateNote = new OperateNote();
            operateNote.SetFileStrategy(typeFile);
            var x = await operateNote.AddFile(fileName, folderId);
            if (x != null)
                return (x, "");
            return (null, "error");

        }
    }
}
