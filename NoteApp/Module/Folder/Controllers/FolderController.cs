﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteApp.App.Controllers;
using NoteApp.App.Database.Data;
using NoteApp.Module.Folder.Request;
using NoteApp.Module.Folder.Services;

namespace NoteApp.Module.Folder.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolderController : BaseController
    {
        private readonly IFolderService _folderService;

        public FolderController(IFolderService folderService)
        {
            _folderService = folderService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetListFolder()
        {
           var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if(token == null)
            {
                return ResponseOk(messageResponse: "Folder cannot found");
            }
            (List<Foldernote> data, string erroeMessage) = _folderService.GetList(token);
             return ResponseOk(dataResponse: data.Select(s => new { FolderId = s.FolderId, FolderName = s.FolderName, Filenotes = s.Filenotes }  ));
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateFolder([FromBody] RequestAddFolder folder)
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            (Foldernote data, string message) = _folderService.CreateFolder(folder.Foldername, token);
            if (!string.IsNullOrEmpty(message))
                return ResponseBadRequest(messageResponse: message);
            return ResponseOk(dataResponse: data);
        }

    }
}
