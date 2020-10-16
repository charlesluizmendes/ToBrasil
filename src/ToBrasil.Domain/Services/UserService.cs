using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToBrasil.Domain.Entities;
using ToBrasil.Domain.Extensions;
using ToBrasil.Domain.Interfaces.Repository;
using ToBrasil.Domain.Interfaces.Services;

namespace ToBrasil.Domain.Services
{
    public class UserService : BaseService<Users>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
            : base(userRepository)
        {
            _userRepository = userRepository;
        }

        public override async Task<Users> InsertAsync(Users user)
        {
            user.Created = DateTime.Now;
            user.Modified = DateTime.Now;
            user.PasswordHash = HasherExtension.HashPassword(user.PasswordHash);

            return await _userRepository.InsertAsync(user);
        }

        public async Task<Users> GetUserByEmailAsync(Users user)
        {
            return await _userRepository.GetUserByEmailAsync(user);
        }

        public async Task<Users> GetUserByLoginAsync(Users user)
        {
            var _user = await _userRepository.GetUserByEmailAsync(user);

            if (_user == null)
            {
                return null;
            }

            var password = HasherExtension.VerifyHashedPassword(_user.PasswordHash, user.PasswordHash);

            if (!password)
            {
                return null;
            }

            _user.LastLogin = DateTime.Now;

            return await _userRepository.UpdateAsync(_user);
        }
    }
}
