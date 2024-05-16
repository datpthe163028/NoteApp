using Microsoft.AspNetCore.Mvc;
using NoteApp.App.Controllers;
using NoteApp.App.Database.Data;
using NoteApp.Module.Majors.Services;

namespace NoteApp.Module.Majors.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MajorController : BaseController
    {
        private IMajorService majorService;
        public MajorController(IMajorService _majorService) {
            majorService = _majorService;
        }

        [HttpGet]
        public IActionResult Index(int universityId)
        {
            (List<Major> data, string message) = majorService.GetListBySchoolId(universityId);
            if (!String.IsNullOrEmpty(message))
                return ResponseBadRequest( messageResponse: message);
            return ResponseOk(dataResponse: data);
        }
    }
}
