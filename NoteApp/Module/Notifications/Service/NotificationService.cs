using NoteApp.App.Database.Data;
using NoteApp.App.DesignPatterns.Repository;
using NoteApp.App.JwtToken.Services;

namespace NoteApp.Module.Notifications.Service
{
    public interface INotificationService
    {
        (List<Notification> data, string erroeMessage) GetList(string token);
    }
    public class NotificationService : INotificationService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IJwtService _jwtService;

        public NotificationService(UnitOfWork unitOfWork, IJwtService jwtService)
        {
            _jwtService = jwtService;
              _unitOfWork = unitOfWork;
        }

        public (List<Notification> data, string erroeMessage) GetList(string token)
        {
            var x = _jwtService.VerifyToken(token);
            if (x == null)
            {
                return (new List<Notification>(), "Notification not found");
            }
            else
            {
                if(x.Notifications == null)
                {
                    return (new List<Notification>(), "");
                }
                return (x.Notifications.ToList(), "");
            }

        }
    }
}
