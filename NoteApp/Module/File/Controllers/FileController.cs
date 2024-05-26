using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteApp.App.Controllers;
using NoteApp.App.Database.Data;
using NoteApp.Module.File.Request;
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
        [Authorize]
        public IActionResult GetListFile(int folderId)
        {
            (List<Filenote> data, string message) = _fileService.GetList(folderId);
            if (!string.IsNullOrEmpty(message))
                return ResponseBadRequest(messageResponse: message);
            return ResponseOk(dataResponse: data);
            //ddd
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateFile(RequestAddFile file)
        {
            (Filenote data, string ErrorMessage) = await _fileService.CreateFile(file.FolderId, file.FileName, file.typeFile);
            if (!string.IsNullOrEmpty(ErrorMessage))
                return ResponseBadRequest();
            else
                return ResponseOk(dataResponse: data);
        }

        //[HttpPut("SimpleNote")]
        ////[Authorize]
        //public async Task<IActionResult> CreateSimpleFile(RequestUpdateSimpleFile model)
        //{
        //    (SimpleNote data, string ErrorMessage) = await _fileService.CreateSimpleFile(model.SimpleNoteId, model.content);
        //    if (!string.IsNullOrEmpty(ErrorMessage))
        //        return ResponseOk(dataResponse: data);
        //    return ResponseOk(dataResponse: data);
        //}

        [HttpDelete("ToDoList")]
        [Authorize]
        public async Task<IActionResult> DeleteToDoList(int id)
        {
             string ErrorMessage = _fileService.DeleteTodoList(id);
            if (!string.IsNullOrEmpty(ErrorMessage))
                return ResponseOk(messageResponse: "Error");
            return ResponseOk(messageResponse: "");
        }

        [HttpGet("ToDoList")]
        [Authorize]
        public async Task<IActionResult> GetTodoList(int fileId)
        {
            (List<DetailToDoList> data, string ErrorMessage) = _fileService.GetListToDoList(fileId);
            if (!string.IsNullOrEmpty(ErrorMessage))
                return ResponseOk(messageResponse: "Error");
            return ResponseOk(dataResponse: data);
        }

        [HttpPut("ToDoList")]
        [Authorize]
        public async Task<IActionResult> UpdateToDolist(RequestUpdateToDoList model)
        {
            (DetailToDoList data, string ErrorMessage) = await _fileService.UpdateTodoList(model);
            if (!string.IsNullOrEmpty(ErrorMessage))
                return ResponseOk(messageResponse: "Error");
            return ResponseOk(dataResponse: data);
        }

        [HttpPost("ToDoList")]
        [Authorize]
        public async Task<IActionResult> CreateToDolist(RequestAddToDoList model)
        {
            (DetailToDoList data, string ErrorMessage) = await _fileService.CreateToDolList(model);
            if (!string.IsNullOrEmpty(ErrorMessage))
                return ResponseOk(messageResponse: "Error");
            return ResponseOk(dataResponse: data);
        }
    }
}
