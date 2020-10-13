using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToBrasil.Application.DTO
{
    public class PhoneDTO
    {
        [Required(ErrorMessage = "O DDD não pode ser nulo")]
        [MinLength(2, ErrorMessage = "O DDD não pode ter menos de 2 caracteres")]
        [MaxLength(2, ErrorMessage= "O DDD não pode ter mais de 2 caracteres")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Digite um DDD válido")]
        public string DDD { get; set; }

        [Required(ErrorMessage = "O Número não pode ser nulo")]
        [MinLength(8, ErrorMessage = "O Número não pode ter menos de 8 caracteres")]
        [MaxLength(9, ErrorMessage= "O Número não pode ter mais de 2 caracteres")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Digite um Número válido")]
        public string Number { get; set; }
    }
}
