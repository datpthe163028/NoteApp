using Microsoft.EntityFrameworkCore;
using NoteApp.App.Database.Data;
using NoteApp.App.DesignPatterns.Strategy;

namespace NoteApp.Module.Semesters.Service
{
    public interface ISemesterService
    {
        (List<Semester> data, string message) GetSemesterBySchoolMajorId(int universityId, int majorId);
    }

    public class SemesterService : ISemesterService
    {
        private UnitOfWork _unitOfWork;

        public SemesterService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public (List<Semester> data, string message) GetSemesterBySchoolMajorId(int universityId, int majorId)
        {
            List<Semester> listSemester = new List<Semester>();

            var universityMajor = _unitOfWork.UniversityMajors.FindByCondition(s => s.UniversityId == universityId && s.MajorId == majorId).Include(s => s.UniversityMajorSemesters).ThenInclude(s => s.Semester).FirstOrDefault();
            if (universityMajor is null)
                return (listSemester, "Not find Semester");

            foreach (var l in universityMajor.UniversityMajorSemesters)
            {
                if (!(l.Semester is null))
                    listSemester.Add(l.Semester);
            }

            if (listSemester.Count == 0)
                return (listSemester, "Not find Semester");
            return (listSemester, string.Empty);
        }

    }
}
