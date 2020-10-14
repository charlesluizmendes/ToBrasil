using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using ToBrasil.Domain.Entities;

namespace ToBrasil.Application.Services.Query
{
    public class GetUserByLoginQuery : IRequest<User>
    {
        public string Email { get; set; }

        public string PasswordHash { get; set; }        
    }
}
