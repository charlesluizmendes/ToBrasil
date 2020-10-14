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
                .FirstOrDefaultAsync(x => x.Email == email);

            return result;
        }
    }
}
