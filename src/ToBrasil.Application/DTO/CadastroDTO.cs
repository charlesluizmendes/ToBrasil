using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToBrasil.Application.DTO
{
    public class CadastroDTO
    {
        [Required(ErrorMessage = "O Nome não pode ser nulo")]
        [MaxLength(255, ErrorMessage = "O Nome não pode ter mais de 255 caracteres")]
        [RegularExpression(@"^[ a-zA-Z á]*$", ErrorMessage = "Digite um Nome válido")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O Email não pode ser nulo")]
        [MaxLength(255, ErrorMessage = "O Email não pode ter mais de 255 caracteres")]
        [EmailAddress(ErrorMessage = "Digite um Email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha não pode ser nula")]
        [MaxLength(255, ErrorMessage = "A Senha não pode ter mais de 255 caracteres")]
        [DataType(DataType.Password, ErrorMessage = "Digite uma Senha válida")]
        public string Password { get; set; }
           
        public List<PhoneDTO> Phones { get; set; }
    }
}
