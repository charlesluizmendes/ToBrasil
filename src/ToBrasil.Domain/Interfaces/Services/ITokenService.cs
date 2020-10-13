using System;
using System.Collections.Generic;
using System.Text;

namespace ToBrasil.Domain.Interfaces.Services
{
    public interface ITokenService
    {
        string Token(string email);
    }
}
