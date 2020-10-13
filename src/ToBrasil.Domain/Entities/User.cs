using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace ToBrasil.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public virtual ICollection<Phone> Phone { get; set; }
    }
}
