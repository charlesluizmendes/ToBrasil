using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public User VerifyEmail(User user)
        {
            var result = _context.Users
                .FirstOrDefault(x => 
                    x.Email == user.Email
                    );

            return result;
        }
    }
}
