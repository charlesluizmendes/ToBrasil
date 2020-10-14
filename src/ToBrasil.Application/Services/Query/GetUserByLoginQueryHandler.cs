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
    public class GetUserByLoginQueryHandler : IRequestHandler<GetUserByLoginQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByLoginQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> Handle(GetUserByLoginQuery request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetUserByEmailAsync(request.Email);

            if (user == null)
            {
                return null;
            }

            var hash = HasherExtension.VerifyHashedPassword(user.Result.PasswordHash, request.PasswordHash);

            if (!hash)
            {
                return null;
            }

            return user;
        }
    }
}
