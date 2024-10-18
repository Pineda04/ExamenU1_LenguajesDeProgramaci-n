using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_U1_Lenguajes.Dtos.Departments
{
    public class DepartmentCreateDto
    {
        // Nombre del departamento
        [Display(Name = "nombre")]
        [StringLength(75, ErrorMessage = "El {0} del departamento debe tener menos de {1} caracteres.")]
        [Required(ErrorMessage = "El {0} del departamento es obligatorio.")]
        public string Name { get; set; }
    }
}