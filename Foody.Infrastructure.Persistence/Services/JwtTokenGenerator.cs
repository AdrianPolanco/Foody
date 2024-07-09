using Foody.Core.Application.Interfaces;
using Foody.Core.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Foody.Infrastructure.Persistence.Services
{
    public class JwtTokenGenerator : IJwtGenerator
    {
        private readonly IConfiguration _configuration;
        private readonly SymmetricSecurityKey _key;
        public JwtTokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
            byte[] key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!);
            _key = new SymmetricSecurityKey(key);
        }
        public string Generate(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            SigningCredentials credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var expireInMinutes = _configuration.GetValue<int>("Jwt:ExpireInMinutes");

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(expireInMinutes),
                Audience = _configuration["Jwt:Audience"],
                Issuer = _configuration["Jwt:Issuer"],
                SigningCredentials = credentials
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
