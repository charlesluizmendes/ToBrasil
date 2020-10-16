using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToBrasil.Domain.Interfaces.Services;

namespace ToBrasil.Application.Services.Query
{
    public class GetTokenByEmailQueryHandler : IRequestHandler<GetTokenByEmailQuery, string[]>
    {
        private readonly ITokenService _tokenService;

        public GetTokenByEmailQueryHandler(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public async Task<string[]> Handle(GetTokenByEmailQuery request, CancellationToken cancellationToken)
        {
            return await _tokenService.CreateJwtToken(request.User);
        }
    }
}
