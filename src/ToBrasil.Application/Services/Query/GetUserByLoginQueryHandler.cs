using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToBrasil.Application.Extensions;
using ToBrasil.Domain.Entities;
using ToBrasil.Domain.Interfaces.Repository;
using ToBrasil.Domain.Interfaces.Services;

namespace ToBrasil.Application.Services.Query
{
    public class GetUserByLoginQueryHandler : IRequestHandler<GetUserByLoginQuery, Users>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByLoginQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Users> Handle(GetUserByLoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.User);

            if (user == null)
            {
                return null;
            }

            var hash = HasherExtension.VerifyHashedPassword(user.PasswordHash, request.User.PasswordHash);

            if (!hash)
            {
                return null;
            }

            user.LastLogin = DateTime.Now;

            return await _userRepository.UpdateAsync(user);
        }
    }
}
