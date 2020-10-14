using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToBrasil.Domain.Entities;
using ToBrasil.Domain.Interfaces.Repository;

namespace ToBrasil.Application.Services.Command
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPhoneRepository _phoneRepository;

        public CreateUserCommandHandler(IUserRepository userRepository,
            IPhoneRepository phoneRepository)
        {
            _userRepository = userRepository;
            _phoneRepository = phoneRepository;
        }

        public Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository.InsertAsync(request.User);

            foreach (var item in user.Result.Phones)
            {
                _phoneRepository.InsertAsync(item);
            };

            return user;
        }
    }
}
