using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_U1_Lenguajes.Dtos.Auth
{
    public class RegisterDto
    {
        [Display(Name = "Correo Electrónico")]
        [Required(ErrorMessage = "EL campo {0} es requerido.")]
        [EmailAddress(ErrorMessage = "El campo {0} no es valido.")]
        public string Email { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        // 1 mayuscula, 1 minuscula, 1 caracter especial, 1 numero, sea mayor a 8 caracteres
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "La contraseña debe ser segura y contener al menos 8 caracteres, incluyendo minúsculas, mayúsculas, números y caracteres especiales.")]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}