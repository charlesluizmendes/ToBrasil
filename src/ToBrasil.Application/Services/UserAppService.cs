using System;
using System.Collections.Generic;
using System.Text;
using ToBrasil.Application.DTO;
using ToBrasil.Application.Extensions;
using ToBrasil.Application.Interfaces;
using ToBrasil.Domain.Entities;
using ToBrasil.Domain.Interfaces.Services;

namespace ToBrasil.Application.Services
{
    public class UserAppService : BaseAppService<User>, IUserAppService
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public UserAppService(IUserService userService,
            ITokenService tokenService)
            : base(userService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }        

        public User VerifyEmail(User user)
        {
            return _userService.VerifyEmail(user);
        }

        public bool VerifyPassword(string passwordHash, string password)
        {
            var hash = HasherExtension.VerifyHashedPassword(passwordHash, password);           

            return hash;
        }

        public string Token(string email)
        {
            return _tokenService.Token(email);
        }
    }
}
