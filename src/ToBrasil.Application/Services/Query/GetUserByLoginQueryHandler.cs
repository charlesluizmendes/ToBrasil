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
    public class GetUserByLoginQueryHandler : IRequestHandler<GetUserByLoginQuery, Users>
    {
        private readonly IUserService _userService;

        public GetUserByLoginQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Users> Handle(GetUserByLoginQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserByLoginAsync(request.User);
        }
    }
}
