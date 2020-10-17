using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToBrasil.Domain.Entities;
using ToBrasil.Domain.Interfaces.Repository;
using ToBrasil.Domain.Interfaces.Services;

namespace ToBrasil.Domain.Services
{
    public class TokenService : BaseService<Token>, ITokenService
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ITokenRepository _tokenRepository;

        public TokenService(IAuthenticationService authenticationService,
            ITokenRepository tokenRepository)
            : base(tokenRepository)
        {
            _authenticationService = authenticationService;
            _tokenRepository = tokenRepository;
        }

        public async Task<Token> CreateTokenByLoginAsync(Users login)
        {
            var token = await _authenticationService.CreateTokenByLoginAsync(login);

            return await _tokenRepository.InsertAsync(token);
        }
    }
}
