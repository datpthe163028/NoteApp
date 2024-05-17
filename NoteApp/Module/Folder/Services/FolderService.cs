using NoteApp.App.Database.Data;
using NoteApp.App.DesignPatterns.UnitOfWork;
using NoteApp.App.JwtToken.Services;

namespace NoteApp.Module.Folder.Services
{
    public interface IFolderService
    {
        (Foldernote data, string message) CreateFolder(string folderName, string token);
        (List<Foldernote> data, string erroeMessage) GetList(string token);
    }
    public class FolderService : IFolderService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IJwtService _jwtService;
        private readonly noteappContext _noteappContext;

        public FolderService(UnitOfWork unitOfWork, IJwtService jwt, noteappContext noteappContext)
        {
            _unitOfWork = unitOfWork;
            _jwtService = jwt;
            _noteappContext = noteappContext;
        }

        public (Foldernote data, string message) CreateFolder(string folderName, string token)
        {
            if(folderName is null || folderName == "")
                return (null, "Not Found");

            var x = _jwtService.VerifyToken(token);
            if (x == null)
                return (null, "Not Found");
            var folder = new Foldernote() { FolderName = folderName, UserId = x.UserId };
            //_unitOfWork.FolderNotes.Add(folder);
            //_unitOfWork.SaveChanges();
            _noteappContext.Foldernotes.Add(folder);
            _noteappContext.SaveChanges();
            return (folder, "");
        }

        public (List<Foldernote> data, string erroeMessage) GetList(string token)
        {
            List<Foldernote> dataList = new List<Foldernote>();
            var x =  _jwtService.VerifyToken(token);
            
            if (x == null)
            {
                return (dataList, "Folder not found");
            }
            else
            {
                return (x.Foldernotes.ToList(), "");
            }
           
        }




    }
}
