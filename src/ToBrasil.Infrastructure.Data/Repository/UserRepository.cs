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

        public User Login(string email)
        {
            var user = _context.Users
                .FirstOrDefault(x => 
                    x.Email.Equals(email)
                    );      

            return user;
        }

        public bool VerifyEmail(string email)
        {
            var exist = _context.User
                .Any(x => 
                    x.Email == email
                    );

            return exist;
        }
    }
}
