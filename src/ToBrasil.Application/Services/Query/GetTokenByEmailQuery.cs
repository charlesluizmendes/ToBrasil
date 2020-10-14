using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToBrasil.Application.Services.Query
{
    public class GetTokenByEmailQuery : IRequest<string>
    {
        public string Email { get; set; }
    }
}
