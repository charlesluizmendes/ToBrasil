using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ToBrasil.Domain.Entities;
using ToBrasil.Domain.Interfaces.Services;

namespace ToBrasil.Infrastructure.Identity.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;

        public AuthenticationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Token> CreateJwtTokenAsync(Users user)
        {
            var claims = new[]
                {
                     new Claim(ClaimTypes.Email, user.Email.ToString()),
                };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:key"])
                );

            var creds = new SigningCredentials(
                key, SecurityAlgorithms.HmacSha256
                );

            var jwt = new JwtSecurityToken(
                issuer: _configuration["Jwt:issuer"],
                audience: _configuration["Jwt:audience"],
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["Jwt:expires"])),
                claims: claims,
                signingCredentials: creds
                );

            var accessKey = new JwtSecurityTokenHandler().WriteToken(jwt);
            var validTo = jwt.ValidTo.ToString();

            return await Task.FromResult(new Token
            {
                Id = user.Token != null ? user.Token.Id : Guid.Empty,
                AccessKey = accessKey,
                ValidTo = validTo,
                UserId = user.Id
            });
        }
    }
}
