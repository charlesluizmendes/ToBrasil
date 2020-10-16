using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ToBrasil.Domain.Entities
{
    public class Phone
    {
        [Key]
        public virtual Guid Id { get; set; }

        [Required]
        public virtual string DDD { get; set; }

        [Required]
        public virtual string Number { get; set; }

        [ForeignKey("User")]
        public virtual Guid UserId { get; set; }
        public virtual Users User { get; set; }
    }
}
