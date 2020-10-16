using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToBrasil.Domain.Entities;

namespace ToBrasil.Domain.Interfaces.Services
{
    public interface IUserService : IBaseService<Users>
    {
        Task<Users> GetUserByEmailAsync(Users user);

        Task<Users> GetUserByLoginAsync(Users user);
    }
}
