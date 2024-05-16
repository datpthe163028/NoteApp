using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteApp.App.Controllers;
using NoteApp.App.Database.Data;
using NoteApp.App.DesignPatterns.UnitOfWork;
using NoteApp.Module.Account.Request;
using NoteApp.Module.Account.Service;

namespace NoteApp.Module.Account.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IAccountService AccountService;
        private readonly UnitOfWork _unitOfWork;
        public AccountController(IAccountService accountService, UnitOfWork uo)
        {
            AccountService = accountService;
            _unitOfWork = uo;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAccountForApp([FromBody] AccountRegisterRequest accountRequest)
        {
            (User account, string errorMessage) = await AccountService.RegisterAsync(accountRequest);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return ResponseBadRequest(errorMessage);
            }
            return ResponseOk(account.FirstName);
        }

        [HttpPost("Auth")]
        public IActionResult Login([FromBody] AccountLoginRequest account)
        {
            return Ok( _unitOfWork.Universities);
        }

    }
}
