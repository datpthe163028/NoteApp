using NoteApp.App.DesignPatterns.Repository;

namespace NoteApp.Module.Club.Service
{
    public interface IClubService
    {
        (List<App.Database.Data.Club> data, string errormessage) GetListRecruit();
    }

    public class ClubService : IClubService
    {
        private readonly UnitOfWork _unitOfWork;
        public ClubService(UnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        (List<App.Database.Data.Club> data, string errormessage) IClubService.GetListRecruit()
        {
            var data = _unitOfWork.Clubs.FindByCondition(s => s.StatusRecruitment == true).ToList();
            if (data.Count() == 0)
            {
                return (data, "empty");
            }
            return (data, "");

        }
    }
}
