using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NoteApp.App.Database.Data;
using NoteApp.App.DesignPatterns.UnitOfWork;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NoteApp.App.JwtToken.Services
{
    public interface IJwtService
    {
        User VerifyToken(string token);
    }

    public class JwtService : IJwtService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public JwtService(UnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration; 
        }

        public User VerifyToken(string token)
        {
            var secretKey = _configuration["JwtSettings:SecretKey"];
            var issuer = _configuration["JwtSettings:Issuer"];

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(secretKey);

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = issuer,
                ValidAudience = issuer,
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };

            try
            {
                // Validate token and get principal
                var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

                // Get claims from principal
                var userIdClaim = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                var roleClaim = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);

                if (userIdClaim == null || roleClaim == null)
                {
                    throw new SecurityTokenException("Invalid token");
                }
                int userId = int.Parse(userIdClaim.Value);
                var x = _unitOfWork.Users.FindByCondition(s => s.UserId == userId).Include(x => x.Foldernotes).FirstOrDefault();
                if (x != null) 
                     return x;
                return null;
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new SecurityTokenException("Token validation failed", ex);
            }


        }
    }
}
