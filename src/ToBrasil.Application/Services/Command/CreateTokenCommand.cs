using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using ToBrasil.Domain.Entities;

namespace ToBrasil.Application.Services.Command
{
    public class CreateTokenCommand : IRequest<User>
    {
        public User User { get; set; }
    }
}
