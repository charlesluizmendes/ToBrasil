using System;
using System.Collections.Generic;
using System.Text;
using ToBrasil.Domain.Entities;

namespace ToBrasil.Domain.Interfaces.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User VerifyEmail(User user);
    }
}
