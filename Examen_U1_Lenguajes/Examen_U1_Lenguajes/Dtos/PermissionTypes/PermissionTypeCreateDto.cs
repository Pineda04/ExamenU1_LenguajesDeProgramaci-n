using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_U1_Lenguajes.Dtos.PermissionTypes
{
    public class PermissionTypeCreateDto
    {
        // Nombre del departamento
        [Display(Name = "nombre")]
        [StringLength(75, ErrorMessage = "El {0} del tipo de permiso debe tener menos de {1} caracteres.")]
        [Required(ErrorMessage = "El {0} del tipo de permiso es obligatorio.")]
        public string Name { get; set; }
    }
}