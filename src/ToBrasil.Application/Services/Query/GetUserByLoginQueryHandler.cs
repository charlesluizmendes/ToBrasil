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
        private readonly ITokenService _tokenService;

        public GetUserByLoginQueryHandler(IUserRepository userRepository,
            ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public Task<User> Handle(GetUserByLoginQuery request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetUserByEmailAsync(request.User);

            if (user == null)
            {
                return null;
            }

            var hash = HasherExtension.VerifyHashedPassword(user.Result.PasswordHash, request.User.PasswordHash);

            if (!hash)
            {
                return null;
            }

            var token = _tokenService.CreateJwtToken(user.Result);

            user.Result.LastLogin = DateTime.Now;
            user.Result.Token = token.Result;

            return _userRepository.UpdateAsync(user.Result);
        }
    }
}
