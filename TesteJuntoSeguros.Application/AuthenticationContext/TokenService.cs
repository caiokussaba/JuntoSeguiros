using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TesteJuntoSeguros.Application.AuthenticationContext.Settings;
using Microsoft.IdentityModel.Tokens;

namespace TesteJuntoSeguros.Application.AuthenticationContext
{
    public static class TokenService
    {
        public static string GenerateToken(string? login)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SettingsSecret.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, login)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
