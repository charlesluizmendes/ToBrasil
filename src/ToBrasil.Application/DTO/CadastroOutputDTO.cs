using System;
using System.Collections.Generic;
using System.Text;

namespace ToBrasil.Application.DTO
{
    public class CadastroOutputDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public List<PhoneDTO> Phones { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }

        public DateTime? LastLogin { get; set; }
    }
}
