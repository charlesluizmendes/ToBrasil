using System;
using System.Collections.Generic;
using System.Text;

namespace ToBrasil.Application.DTO
{
    public class LoginOutputDTO
    {
        public UserDTO User { get; set; }

        public TokenDTO Token { get; set; }
    }
}
