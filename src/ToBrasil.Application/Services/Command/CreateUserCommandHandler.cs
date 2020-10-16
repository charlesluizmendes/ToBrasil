using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToBrasil.Domain.Entities;
using ToBrasil.Domain.Interfaces.Services;

namespace ToBrasil.Application.Services.Command
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Users>
    {
        private readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Users> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.InsertAsync(request.User);
        }
    }
}
