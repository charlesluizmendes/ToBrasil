using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToBrasil.Application.Extensions;
using ToBrasil.Domain.Entities;
using ToBrasil.Domain.Interfaces.Repository;

namespace ToBrasil.Application.Services.Command
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Users>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Users> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            request.User.Created = DateTime.Now;
            request.User.Modified = DateTime.Now;
            request.User.PasswordHash = HasherExtension.HashPassword(request.User.PasswordHash);

            return await _userRepository.InsertAsync(request.User);
        }
    }
}
