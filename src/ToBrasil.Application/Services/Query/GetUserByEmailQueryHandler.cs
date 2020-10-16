using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToBrasil.Domain.Entities;
using ToBrasil.Domain.Interfaces.Services;

namespace ToBrasil.Application.Services.Query
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, Users>
    {
        private readonly IUserService _userService;

        public GetUserByEmailQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Users> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserByEmailAsync(request.User);
        }
    }
}
