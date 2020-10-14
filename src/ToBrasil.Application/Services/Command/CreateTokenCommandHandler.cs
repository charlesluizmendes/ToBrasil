using MediatR;
using System;
using System.Collections.Generic;
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
        private readonly IPhoneRepository _phoneRepository;

        public CreateTokenCommandHandler(ITokenService tokenService,
            IUserRepository userRepository,
            IPhoneRepository phoneRepository)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
            _phoneRepository = phoneRepository;
        }

        public Task<User> Handle(CreateTokenCommand request, CancellationToken cancellationToken)
        {
            var token = _tokenService.CreateJwtToken(request.User);

            var user = _userRepository.GetUserByEmailAsync(request.User.Email);
            user.Result.LastLogin = DateTime.Now;
            user.Result.Token = token.Result;
          
            return _userRepository.UpdateAsync(user.Result);
        }
    }
}
