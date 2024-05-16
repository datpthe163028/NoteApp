using Microsoft.AspNetCore.Mvc;
using NoteApp.App.Controllers;
using NoteApp.App.Database.Data;
using NoteApp.Module.Semesters.Service;

namespace NoteApp.Module.Semesters.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SemesterController : BaseController
    {
        private ISemesterService _semesterService;
        public SemesterController(ISemesterService semesterService) { 
            _semesterService = semesterService;
        }
        [HttpGet]
        public IActionResult Index(int universityId, int majorId)
        {
            (List<Semester> data, string message)  = _semesterService.GetSemesterBySchoolMajorId(universityId, majorId);
            if(!string.IsNullOrEmpty(message))
                return ResponseBadRequest( messageResponse: message);
            return ResponseOk(dataResponse: data);
        }
    }
}
