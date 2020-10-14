using System;
using System.Collections.Generic;
using System.Text;

namespace ToBrasil.Application.DTO
{
    public class LoginOutputDTO
    {
        public LoginInputDTO Login { get; set; }

        public string Token { get; set; }
    }
}
