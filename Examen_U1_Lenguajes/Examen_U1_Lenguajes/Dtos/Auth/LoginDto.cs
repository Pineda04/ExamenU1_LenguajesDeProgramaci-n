using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_U1_Lenguajes.Dtos.Auth
{
    public class LoginDto
    {
        [Display(Name = "Correo Electrónico")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string Email { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "La {0} es obligatoria")]
        public string Password { get; set; }
    }
}