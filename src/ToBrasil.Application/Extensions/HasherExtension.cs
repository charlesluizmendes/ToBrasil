using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using ToBrasil.Domain.Entities;

namespace ToBrasil.Application.Extensions
{
    public class HasherExtension
    {
        public static string HashPassword(string password)
        {
            var hasher = new PasswordHasher<Users>();
            var hashPassword = hasher.HashPassword(null, password);

            return hashPassword;
        }

        public static bool VerifyHashedPassword(string passwordHash, string providedPassword)
        {
            var hasher = new PasswordHasher<Users>();
            var verify = hasher.VerifyHashedPassword(null, passwordHash, providedPassword);

            if (verify == PasswordVerificationResult.Success)
            {
                return true;
            }

            return false;
        }
    }
}
