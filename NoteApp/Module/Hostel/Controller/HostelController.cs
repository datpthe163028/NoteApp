using Microsoft.AspNetCore.Mvc;
using NoteApp.Module.Hostels.Service;
using NoteApp.Module.Hostel.Request;
using NoteApp.Module.Hostel.Response;
using NoteApp.App.BaseReponse;

namespace NoteApp.Module.Hostel.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostelController : ControllerBase
    {
        private readonly IHostelService _hostelService;

        public HostelController(IHostelService hostelService)
        {
            _hostelService = hostelService;
        }

        [HttpPost("list")]
        public ActionResult<ApiResponse<List<HostelResponse>>> GetList([FromBody] HostelRequest request)
        {
            try
            {
                var result = _hostelService.GetList(request);
                return Ok(new ApiResponse<List<HostelResponse>>(result, "Success", 200));
            }
            catch
            {
                return StatusCode(500, new ApiResponse<List<HostelResponse>>(null, "Internal Server Error", 500));
            }
        }

        [HttpGet("detail")]
        public ActionResult<ApiResponse<HostelResponse>> Get(int id)
        {
            try
            {
                var result = _hostelService.Get(id);
                if (result == null)
                {
                    return NotFound(new ApiResponse<HostelResponse>(null, "Not Found", 404));
                }
                return Ok(result);
            }
            catch
            {
                return StatusCode(500, new ApiResponse<HostelResponse>(null, "Internal Server Error", 500));
            }
        }

        [HttpPost("add")]
        public ActionResult<ApiResponse<bool>> Add([FromBody] HostelRequest request)
        {
            try
            {
                var result = _hostelService.Add(request);
                return Ok(new ApiResponse<bool>(result, "Success", 200));
            }
            catch
            {
                return StatusCode(500, new ApiResponse<bool>(false, "Internal Server Error", 500));
            }
        }
    }
}
