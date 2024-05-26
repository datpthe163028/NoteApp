using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using NoteApp.App.Controllers;
using NoteApp.App.Database.Data;
using NoteApp.Module.Notifications.Service;

namespace NoteApp.Module.Notifications.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : BaseController
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetList()
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token == null)
            {
                return ResponseOk(messageResponse: "Folder cannot found");
            }
            (List<Notification> data, string erroeMessage) = _notificationService.GetList(token);
            return ResponseOk(dataResponse: data.Select(s => new { Header = s.Header, Content = s.Content }));
        }
    }
}
