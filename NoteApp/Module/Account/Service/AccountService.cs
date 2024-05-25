using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NoteApp.App.Database.Data;
using NoteApp.App.DesignPatterns.Repository;
using NoteApp.Common.Email;
using NoteApp.Common.Token;
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
        Task<bool> CheckVerificationServiceAsync(string token);

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
        public async Task<bool> CheckVerificationServiceAsync(string token)
        {
            try
            {
                if (string.IsNullOrEmpty(token))
                {
                    return false;
                }

                var user = await _noteappContext.Users
                    .FirstOrDefaultAsync(u => u.VerificationToken == token);

                if (user == null)
                {
                    return false;
                }
                user.Active = true;
                _noteappContext.Update(user);
                _noteappContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking verification service: {ex.Message}");
                return false;
            }
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
                string verificationToken = TokenSerivce.GenerateVerificationToken();

                var newUser = new User
                {
                    FirstName = account.FirstName,
                    LastName = account.LastName,
                    Email = account.Email,
                    Pass = account.Password,
                    Active = false,
                    VerificationToken = verificationToken
                };

                _noteappContext.Users.Add(newUser);
                await _noteappContext.SaveChangesAsync();

                var verificationLink = $"https://localhost:7144/api/Account/verify?token={newUser.VerificationToken}";
                await SendVerificationEmail(newUser.Email, verificationLink);

                return (newUser, "Register Ok, Please check the your email to confirm!");
            }
            catch (Exception ex)
            {
                return (null, $"An error occurred while registering: {ex.Message}");
            }
        }

        private async Task SendVerificationEmail(string email, string verificationLink)
        {
            try
            {
                var emailService = new EmailService();
                var subject = "Verify your email";
                var body = $"Click <a href='{verificationLink}'>here</a> to verify your email.";

                await emailService.SendEmailAsync(email, subject, body);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending verification email: {ex.Message}");
                
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
