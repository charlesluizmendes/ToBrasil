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
        public readonly IUserService _userService;

        public UserAppService(IUserService userService)
            : base(userService)
        {
            _userService = userService;
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
            return _userService.Token(email);
        }
    }
}
