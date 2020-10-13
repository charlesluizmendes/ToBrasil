using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToBrasil.Application.DTO
{
    public class PhoneDTO
    {
        [Required(ErrorMessage = "O DDD não pode ser nulo")]
        [MaxLength(2)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Digite um DDD válido")]
        public string DDD { get; set; }

        [Required(ErrorMessage = "O Número não pode ser nulo")]
        [MaxLength(9)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Digite um Número válido")]
        public string Number { get; set; }
    }
}
