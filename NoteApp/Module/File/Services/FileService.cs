using Microsoft.EntityFrameworkCore;
using NoteApp.App.Database.Data;
using NoteApp.App.DesignPatterns.Repository;
using NoteApp.App.DesignPatterns.Strategy;
using NoteApp.Module.Folder.Services;
using System.Runtime.CompilerServices;

namespace NoteApp.Module.File.Services
{
    public interface IFileService
    {
        Task<(Filenote? data, string ErrorMessage)> CreateFile(int folderId, string filename, string typeFile);
        Task<(SimpleNote data, string ErrorMessage)> CreateSimpleFile(int simpleNoteId, string content);
        (List<Filenote> Filenote, string message) GetList(int folderId);
    }
    public class FileService : IFileService
    {
        private readonly UnitOfWork unitOfWork;
        private readonly OperateNote operateNote;
        public FileService(UnitOfWork uno, OperateNote operateNote)
        {
            unitOfWork = uno;
            this.operateNote = operateNote;
        }
        public (List<Filenote> Filenote, string message) GetList(int folderId)
        {
            var x = unitOfWork.FolderNotes.FindByCondition(s => s.FolderId == folderId).Include(s => s.Filenotes).FirstOrDefault();
            if (x == null)
                return (null, "folder not found");

            return (x.Filenotes.ToList(), "");
        }

        public async Task<(Filenote? data, string ErrorMessage)> CreateFile(int folderId, string fileName, string typeFile)
        {
            if (string.IsNullOrEmpty(fileName))
                return (null, "error");

            operateNote.SetFileStrategy(typeFile);
            var x = await operateNote.AddFile(fileName, folderId);
            if (x != null)
                return (x, "");
            return (null, "error");

        }

        public async Task<(SimpleNote data, string ErrorMessage)> CreateSimpleFile(int simpleNoteId, string content)
        {
            var simpleFile = unitOfWork.SimpleNotes.FindByCondition(s => s.SimpleNoteId == simpleNoteId).FirstOrDefault();
            if (simpleFile == null)
            {
                return (null, "error");
            }
            else
            {
                simpleFile.Content = content;
                unitOfWork.SimpleNotes.Update(simpleFile);
                await unitOfWork.SaveChangesAsync();
                return (simpleFile, "");
            }
        }
    }
}
