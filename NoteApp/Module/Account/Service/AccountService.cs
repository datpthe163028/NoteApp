using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NoteApp.App.Database.Data;
using NoteApp.App.DesignPatterns.Repository;
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
        private readonly noteappContext _noteappContext;

        public AccountService (UnitOfWork unitOfWork, IConfiguration configuration, noteappContext noteappContext)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _noteappContext = noteappContext;
        }


        public async Task<(User Account, string ErrorMessage)> RegisterAsync(AccountRegisterRequest account)
        {
            try
            {
                if (account.Password != account.RePassword)
                {
                    return (null, "Passwords do not match");
                }

                var existingUser = await _unitOfWork.Users.FindByCondition(u => u.Email == account.Email).FirstOrDefaultAsync();
                if (existingUser != null)
                {
                    return (null, "Email has been already used");
                }

                var newUser = new User
                {
                    FirstName = account.FirstName,
                    LastName = account.LastName,
                    Email = account.Email,
                    Pass = account.Password,
                    Active = true
                };

                _noteappContext.Users.Add(newUser);
                await _noteappContext.SaveChangesAsync();

                return (newUser, "Register Ok");
            }
            catch (Exception ex)
            {
                return (null, $"An error occurred while registering: {ex.Message}");
            }
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
