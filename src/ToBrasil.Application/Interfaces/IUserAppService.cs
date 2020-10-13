using System;
using System.Collections.Generic;
using System.Text;
using ToBrasil.Application.DTO;
using ToBrasil.Domain.Entities;

namespace ToBrasil.Application.Interfaces
{
    public interface IUserAppService : IBaseAppService<User>
    {      
        User VerifyEmail(User user);

        bool VerifyPassword(string passwordHash, string password);

        string Token(string email);
    }
}
