using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace ToBrasil.Domain.Entities
{
    public class Token
    {
        [Key]
        public virtual Guid Id { get; set; }

        [Required]
        public virtual string AccessKey { get; set; }

        [Required]
        public virtual string ValidTo { get; set; }

        [ForeignKey("User")]
        public virtual Guid UserId { get; set; }
        public virtual Users User { get; set; }
    }
}
