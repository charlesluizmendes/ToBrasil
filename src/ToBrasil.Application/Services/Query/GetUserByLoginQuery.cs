using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using ToBrasil.Domain.Entities;

namespace ToBrasil.Application.Services.Query
{
    public class GetUserByLoginQuery : IRequest<Users>
    {
        public Users User { get; set; }

    }
}
