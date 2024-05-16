
using Microsoft.EntityFrameworkCore;
using NoteApp.App.Database.Data;
using NoteApp.App.DesignPatterns.UnitOfWork;

namespace NoteApp.Module.Majors.Services
{
    public interface IMajorService
    {
        (List<Major> data, string message) GetListBySchoolId(int universityId);
    }
    public class MajorService : IMajorService
    {
        private UnitOfWork unitOfWork;
        public MajorService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public  (List<Major> data, string message) GetListBySchoolId(int universityId)
        {
            List<Major> listmajor = new List<Major>();

            var uni = unitOfWork.Universities.FindByCondition(u => u.UniversityId == universityId).Include(s => s.UniversityMajors).ThenInclude(s => s.Major).FirstOrDefault();
            if (uni is null)
                return (listmajor, "Not find major");
            
            foreach (var u in uni.UniversityMajors)
            {
                if(u.Major != null)
                     listmajor.Add(u.Major);
            }

            if(listmajor.Count == 0)
                return (listmajor, "Not find major");

            return (listmajor, string.Empty);
        }
    }
}
