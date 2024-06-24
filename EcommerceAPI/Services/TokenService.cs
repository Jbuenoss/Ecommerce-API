using EcommerceAPI.Dto;
using EcommerceAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EcommerceAPI.Services
{
    public class TokenService
    {
        public string GenerateToken(User user)
        {
            //token generator and validator
            var tokenHandler = new JwtSecurityTokenHandler();
            //encoding the secret key
            var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
            //describe the token properties
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Role, "user"),
                    new Claim("id", user.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(2), //each 2 days the user have to make login
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature),
            };
            // Create a token based on the properties
            var token = tokenHandler.CreateToken(tokenDescriptor);
            //convert to a string
            return tokenHandler.WriteToken(token);
        }
    }
}
