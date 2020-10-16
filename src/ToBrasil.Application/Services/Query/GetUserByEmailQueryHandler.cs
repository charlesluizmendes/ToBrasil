using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToBrasil.Domain.Entities;
using ToBrasil.Domain.Interfaces.Repository;

namespace ToBrasil.Application.Services.Query
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, Users>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByEmailQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Users> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var teste = await _userRepository.GetAllAsync();

            return await _userRepository.GetUserByEmailAsync(request.User);
        }
    }
}
