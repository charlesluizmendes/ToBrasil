using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToBrasil.Domain.Entities;
using ToBrasil.Domain.Interfaces.Repository;
using ToBrasil.Infrastructure.Data.Context;

namespace ToBrasil.Infrastructure.Data.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ToBrasilContext _context;

        public UserRepository(ToBrasilContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var result = await _context.Users
                .Where(u => u.Email == email)
                .Select(u => new User
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Email = u.Email,
                    PasswordHash = u.PasswordHash,
                    Phones = u.Phones.Where(p => p.UserId == u.Id).ToList(),
                    Created = u.Created,
                    Modified = u.Modified,
                    LastLogin = u.LastLogin,
                    Token = u.Token,
                    ConcurrencyStamp = u.ConcurrencyStamp
                })
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
