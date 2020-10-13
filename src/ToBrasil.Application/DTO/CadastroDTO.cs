using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToBrasil.Application.DTO
{
    public class CadastroDTO
    {
        [Required(ErrorMessage = "O Nome não pode ser nulo")]
        [MaxLength(255)]
        [RegularExpression(@"^[ a-zA-Z á]*$", ErrorMessage = "Digite um Nome válido")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O Email não pode ser nulo")]
        [MaxLength(255)]
        [EmailAddress(ErrorMessage = "Digite um Email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha não pode ser nula")]
        [MaxLength(255)]
        [DataType(DataType.Password, ErrorMessage = "Digite uma Senha válida")]
        public string Password { get; set; }
           
        public List<PhoneDTO> Phones { get; set; }
    }
}
