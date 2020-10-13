using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using ToBrasil.Domain.Entities;
using ToBrasil.Domain.Interfaces.Repository;
using ToBrasil.Domain.Interfaces.Services;

namespace ToBrasil.Domain.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public UserService(IConfiguration configuration,
            IUserRepository userRepository)
            : base(userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public User Login(string email)
        {
            return _userRepository.Login(email);            
        }

        public bool VerifyEmail(string email)
        {
            return _userRepository.VerifyEmail(email);
        }

        public string Token(string email)
        {
            var claims = new[]
                {
                     new Claim(ClaimTypes.Email, email.ToString()),
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

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return token;
        }        
    }
}
