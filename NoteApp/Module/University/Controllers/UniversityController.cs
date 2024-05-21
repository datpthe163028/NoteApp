using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteApp.App.Controllers;
using NoteApp.App.DesignPatterns.Repository;

namespace NoteApp.Module.University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : BaseController
    {
        private UnitOfWork _uo;
        public  UniversityController(UnitOfWork uo)
        {
            _uo = uo;
        }
        [HttpGet]
        public IActionResult GetUniversity()
        {
            return ResponseOk(dataResponse : _uo.Universities.FindAll());
        }
    }
}
