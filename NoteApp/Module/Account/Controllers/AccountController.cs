using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteApp.App.Controllers;
using NoteApp.App.Database.Data;
using NoteApp.App.DesignPatterns.Repository;
using NoteApp.Common.Appsetting;
using NoteApp.Module.Account.Request;
using NoteApp.Module.Account.Service;
using static System.Net.WebRequestMethods;

namespace NoteApp.Module.Account.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;
        private readonly IAppsettingService _appsettingService;
        private readonly UnitOfWork _unitOfWork;

        public AccountController(IAccountService accountService, UnitOfWork uo, IAppsettingService appsettingService)
        {
            _accountService = accountService;
            _unitOfWork = uo;
            _appsettingService = appsettingService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAccountForApp([FromBody] AccountRegisterRequest accountRequest)
        {
            (User account, string errorMessage) = await _accountService.RegisterAsync(accountRequest);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return ResponseBadRequest(errorMessage);
            }
            return ResponseOk(account.FirstName);
        }

        [HttpPost("Auth")]
        public async Task<IActionResult> Login([FromBody] AccountLoginRequest account)
        {
            (string accessToken, string errorMessage) = await _accountService.AuthAsync(account);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                ResponseOk(messageResponse: errorMessage );
            }
            return ResponseOk(dataResponse: accessToken);
        }


        [HttpGet]
        [Authorize]
        public IActionResult GetAccount()
        {
            return Ok();
        }

        [HttpGet("verify")]
        public async Task<IActionResult> VerifyEmail(string token)
        {
            var isVerified = await _accountService.CheckVerificationServiceAsync(token);

            if (isVerified)
            {
                var urlRedirect = _appsettingService.GetValueByKey("FRONT_END_URL");
                if (string.IsNullOrEmpty(urlRedirect))
                {
                    urlRedirect = "https://localhost:4200";
                }
                return Redirect(urlRedirect);
            }
            else
            {
                return BadRequest("Verification failed or token invalid");
            }
        }
    }
}
