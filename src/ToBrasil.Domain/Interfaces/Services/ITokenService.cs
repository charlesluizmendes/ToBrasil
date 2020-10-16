using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToBrasil.Domain.Entities;

namespace ToBrasil.Domain.Interfaces.Services
{
    public interface ITokenService
    {
        Task<string []> CreateJwtToken(Users user);
    }
}
