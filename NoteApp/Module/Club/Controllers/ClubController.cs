using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteApp.App.Controllers;
using NoteApp.App.Database.Data;
using NoteApp.Module.Club.Service;
namespace NoteApp.Module.Club.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController :  BaseController
    {
        private readonly IClubService _clubService;

        public ClubController(IClubService clubService) {
            _clubService = clubService;
        }

        [HttpGet("Recruitment")]
        //[Authorize]
        public IActionResult GetListClubRecruit()
        {
        
            (List<NoteApp.App.Database.Data.Club> data, string errormessage) = _clubService.GetListRecruit();
            if (errormessage != "")
                return ResponseOk( messageResponse: errormessage );
            return ResponseOk(dataResponse: data); 

        }
    }
}
