using System;
using System.Collections.Generic;
using System.Text;

namespace ToBrasil.Application.DTO
{
    public class LoginOutputDTO
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }
    }
}
