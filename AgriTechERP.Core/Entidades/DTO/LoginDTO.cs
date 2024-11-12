using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriTechERP.Core.Entidades.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Este campo no puede ser vacío.")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Este campo no puede ser vacío.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
