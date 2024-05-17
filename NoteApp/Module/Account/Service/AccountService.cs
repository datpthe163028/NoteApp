using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NoteApp.App.Database.Data;
using NoteApp.App.DesignPatterns.UnitOfWork;
using NoteApp.Module.Account.Request;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NoteApp.Module.Account.Service
{
    public interface IAccountService
    {
        Task<(string accessToken, string errorMessage)> AuthAsync(AccountLoginRequest accountAuthRequest);
        Task<(User Account, string ErrorMessage)> RegisterAsync(AccountRegisterRequest account);
    }

    public class AccountService : IAccountService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public AccountService (UnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration; 
        }


        public Task<(User Account, string ErrorMessage)> RegisterAsync(AccountRegisterRequest account)
        {
            throw new NotImplementedException();
        }

        public async  Task<(string accessToken, string errorMessage)> AuthAsync(AccountLoginRequest accountAuthRequest)
        {
            string accessToken = "";
            var ac = _unitOfWork.Users.FindByCondition(s => s.Email.Equals(accountAuthRequest.email) && s.Pass.Equals(accountAuthRequest.password)).Include(s => s.Role).FirstOrDefault() ;
            if(ac is null)
            {
                return ("", "Account not found");
            }

            if(ac.Active is false)
            {
                return ("", "Account doesn't active");
            }

            return (await GenerateJwtTokenTw(ac), "");


        }

        private async Task<string> GenerateJwtTokenTw(User account)
        {
            var secretKey = _configuration["JwtSettings:SecretKey"];
            var issuer = _configuration["JwtSettings:Issuer"];

            List<Claim> claims = new()
    {
        new Claim(ClaimTypes.NameIdentifier, account.UserId.ToString()),
        new Claim(ClaimTypes.Role, account.Role.RoleName)
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: issuer,
                audience: issuer,
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }


    }
}
