using System;
using System.Collections.Generic;
using System.Text;
using ToBrasil.Domain.Entities;

namespace ToBrasil.Domain.Interfaces.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User Login(string email);

        bool VerifyEmail(string email);
    }
}
