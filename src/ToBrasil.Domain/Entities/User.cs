using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace ToBrasil.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public virtual DateTime Created { get; set; }

        public virtual DateTime Modified { get; set; }

        public virtual DateTime? LastLogin { get; set; }

        public virtual ICollection<Phone> Phone { get; set; }

        public virtual string Token { get; set; }
    }
}
