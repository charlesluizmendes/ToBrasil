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
    public class GetTokenByLoginQueryHandler : IRequestHandler<GetTokenByLoginQuery, Token>
    {
        private readonly ITokenService _tokenService;

        public GetTokenByLoginQueryHandler(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public async Task<Token> Handle(GetTokenByLoginQuery request, CancellationToken cancellationToken)
        {
            return await _tokenService.CreateTokenByLoginAsync(request.Login);
        }
    }
}
