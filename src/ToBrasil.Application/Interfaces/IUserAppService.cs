using System;
using System.Collections.Generic;
using System.Text;
using ToBrasil.Domain.Entities;

namespace ToBrasil.Application.Interfaces
{
    public interface IUserAppService : IBaseAppService<User>
    {
        bool Login(string email, string password);

        bool VerifyEmail(string email);

        string Token(string email);
    }
}
