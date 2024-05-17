using NoteApp.App.Database.Data;
using NoteApp.App.DesignPatterns.UnitOfWork;
using NoteApp.App.JwtToken.Services;

namespace NoteApp.Module.Folder.Services
{
    public interface IFolderService
    {
        (List<Foldernote> data, string erroeMessage) GetList(string token);
    }
    public class FolderService : IFolderService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IJwtService _jwtService;

        public FolderService(UnitOfWork unitOfWork, IJwtService jwt)
        {
            _unitOfWork = unitOfWork;
            _jwtService = jwt;
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
