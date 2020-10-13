using System;
using System.Collections.Generic;
using System.Text;
using ToBrasil.Application.Extensions;
using ToBrasil.Application.Interfaces;
using ToBrasil.Domain.Entities;
using ToBrasil.Domain.Interfaces.Services;

namespace ToBrasil.Application.Services
{
    public class UserAppService : BaseAppService<User>, IUserAppService
    {
        public readonly IUserService _userService;

        public UserAppService(IUserService userService)
            : base(userService)
        {
            _userService = userService;
        }

        public bool Login(string email, string password)
        {
            var user = _userService.Login(email);

            var hash = HasherExtension.VerifyHashedPassword(user.PasswordHash, password);           

            return hash;
        }

        public bool VerifyEmail(string email)
        {
            return _userService.VerifyEmail(email);
        }

        public string Token(string email)
        {
            return _userService.Token(email);
        }

        
    }
}
