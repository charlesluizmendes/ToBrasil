using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace ToBrasil.Domain.Entities
{
    public class Users : IdentityUser<Guid>
    {
        public virtual ICollection<Phone> Phones { get; set; }

        public virtual DateTime Created { get; set; }

        public virtual DateTime? Modified { get; set; }

        public virtual DateTime? LastLogin { get; set; }
    }
}
