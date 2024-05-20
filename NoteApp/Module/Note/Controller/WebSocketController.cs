using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using NoteApp.Module.Note.Service;

namespace NoteApp.Module.Note.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebSocketController : ControllerBase
    {
        private readonly INoteWebSocketService _webSocketService;

        public WebSocketController(INoteWebSocketService webSocketService)
        {
            _webSocketService = webSocketService;
        }

        [HttpGet("/note")]
        public async Task Get()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                await _webSocketService.ProcessWebSocketSession(webSocket);
            }
            else
            {
                HttpContext.Response.StatusCode = 400;
            }
        }
    }
}
