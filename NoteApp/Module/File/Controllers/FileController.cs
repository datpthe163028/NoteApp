using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteApp.App.Controllers;
using NoteApp.App.Database.Data;
using NoteApp.Module.File.Services;

namespace NoteApp.Module.File.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : BaseController
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet]
        public IActionResult GetListFile(int folderId)
        {
            (List<Filenote> data, string message) = _fileService.GetList(folderId);
            if(!string.IsNullOrEmpty(message))
                return ResponseBadRequest(messageResponse: message);
            return ResponseOk(dataResponse: data);
        }

        
    }
}
