using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToBrasil.Application.DTO
{
    public class LoginInputDTO
    {
        [Required(ErrorMessage = "O Email não pode ser nulo")]
        [MaxLength(255, ErrorMessage = "O Email não pode ter mais de 255 carácteres")]
        [EmailAddress(ErrorMessage = "Digite um Email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha não pode ser nula")]
        [MaxLength(255, ErrorMessage = "A Senha não pode ter mais de 255 carácteres")]
        [DataType(DataType.Password, ErrorMessage = "Digite uma Senha válida")]
        public string Password { get; set; }
    }
}
