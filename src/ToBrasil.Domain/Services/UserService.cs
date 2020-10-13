using System;
using System.Collections.Generic;
using System.Text;
using ToBrasil.Domain.Entities;
using ToBrasil.Domain.Interfaces.Repository;
using ToBrasil.Domain.Interfaces.Services;

namespace ToBrasil.Domain.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
            : base(userRepository)
        {
            _userRepository = userRepository;
        }

        public User VerifyEmail(User user)
        {
            return _userRepository.VerifyEmail(user);
        }                
    }
}
