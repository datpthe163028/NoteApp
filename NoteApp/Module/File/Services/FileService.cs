using Microsoft.EntityFrameworkCore;
using NoteApp.App.Database.Data;
using NoteApp.App.DesignPatterns.UnitOfWork;
using NoteApp.Module.Folder.Services;

namespace NoteApp.Module.File.Services
{
    public interface IFileService
    {
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
    }
}
