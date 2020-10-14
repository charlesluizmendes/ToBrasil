using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToBrasil.Domain.Entities;
using ToBrasil.Domain.Interfaces.Repository;
using ToBrasil.Domain.Interfaces.Services;

namespace ToBrasil.Application.Services.Command
{
    public class CreateTokenCommandHandler : IRequestHandler<CreateTokenCommand, User>
    {
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;

        public CreateTokenCommandHandler(ITokenService tokenService,
            IUserRepository userRepository)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        public Task<User> Handle(CreateTokenCommand request, CancellationToken cancellationToken)
        {
            var token = _tokenService.CreateJwtToken(request.User);

            var user = _userRepository.GetUserByEmailAsync(request.User.Email).Result;
            user.LastLogin = DateTime.Now;
            user.Token = token.Result;

            return _userRepository.UpdateAsync(user);
        }
    }
}
