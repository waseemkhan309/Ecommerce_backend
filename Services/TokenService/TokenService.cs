using Ecommerce_backend.DTOs.TokenDto;
using Ecommerce_backend.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ecommerce_backend.Services.TokenService
{
    public class TokenService(
        IConfiguration configuration
        
        ) : ITokenService
    {
        private readonly IConfiguration _configuration = configuration;

        public string CreateAccessToken(UserClaim userClaim)
        {
            // configurations from appsettings
            var jwtKey = _configuration["Jwt:Key"] ??  throw new InvalidOperationException("Jwt:Key is not configured.");
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var expiryMintes = int.Parse(_configuration["Jwt:ExpiryMintes"] ?? "60");


            // claims
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, userClaim.Id.ToString()),
                new(JwtRegisteredClaimNames.Email, userClaim.Email),
                new(ClaimTypes.Name, userClaim.Username),
                new(ClaimTypes.Role, userClaim.Role),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiryMintes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
