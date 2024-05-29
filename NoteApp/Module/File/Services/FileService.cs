using Microsoft.EntityFrameworkCore;
using NoteApp.App.Database.Data;
using NoteApp.App.DesignPatterns.Repository;
using NoteApp.App.DesignPatterns.Strategy;
using NoteApp.Module.File.Request;
using NoteApp.Module.Folder.Services;
using System.Runtime.CompilerServices;

namespace NoteApp.Module.File.Services
{
    public interface IFileService
    {
        Task<(Filenote? data, string ErrorMessage)> CreateFile(int folderId, string filename, string typeFile);
        Task<(SimpleNote data, string ErrorMessage)> CreateSimpleFile(int simpleNoteId, string content);
        Task<(DetailToDoList data, string ErrorMessage)> CreateToDolList(RequestAddToDoList model);
        string DeleteTodoList(int id);
        (List<Filenote> Filenote, string message) GetList(int folderId);
        (List<DetailToDoList> data, string ErrorMessage) GetListToDoList(int fileId);
        Task<(DetailToDoList data, string ErrorMessage)> UpdateTodoList(RequestUpdateToDoList model);
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

        public string DeleteTodoList(int id)
        {
            var file = unitOfWork.ToDoListDetails.FindByCondition(x => x.DetailToDoListId == id).FirstOrDefault();

            if (file == null)
                return "error";
            else
            {
                unitOfWork.ToDoListDetails.Remove(file);
                unitOfWork.SaveChanges();
                return "";
            }
              

        }

        public (List<DetailToDoList> data, string ErrorMessage) GetListToDoList(int fileId)
        {
            var list = unitOfWork.ToDoListDetails.FindByCondition(x => x.ToDoListNoteId == fileId);
            if (list == null || list.Count() == 0)
                return (new List<DetailToDoList>(), "error");
            return (list.ToList(), "");

        }

        public async Task<(DetailToDoList data, string ErrorMessage)> UpdateTodoList(RequestUpdateToDoList model)
        {
            var temp = unitOfWork.ToDoListDetails.FindByCondition(c => c.DetailToDoListId == model.DetailToDoListId).FirstOrDefault();
            if (temp == null)
            {
                return (null, "error");
            }
            temp.Status = model.Status;
            temp.Due = model.Due;
            temp.TaskName = model.TaskName;

            unitOfWork.ToDoListDetails.Update(temp);
            await unitOfWork.SaveChangesAsync();
            return (temp, "" );
           
        }

        public async Task<(DetailToDoList data, string ErrorMessage)> CreateToDolList(RequestAddToDoList model)
        {
            try
            {
                var x = new DetailToDoList() { Due = model.Due, TaskName = model.TaskName, Status = model.Status, ToDoListNoteId = model.ToDoListNoteId };
                unitOfWork.ToDoListDetails.Add(x);
                await unitOfWork.SaveChangesAsync();
                return (x, "");
            }
            catch (Exception ex)
            {
                return(null, "error");
            }
        }
    }
}
