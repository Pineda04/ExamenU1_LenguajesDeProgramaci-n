using System.ComponentModel.DataAnnotations;
using Examen_U1_Lenguajes.Dtos.Departments;

namespace Examen_U1_Lenguajes.Dtos.JobTitles
{
    public class JobTitleCreateDto
    {
        // Nombre del puesto
        [Display(Name = "nombre")]
        [StringLength(75, ErrorMessage = "El {0} del puesto de trabajo debe tener menos de {1} caracteres.")]
        [Required(ErrorMessage = "El {0} del puesto de trabajo es obligatorio.")]
        public string Name { get; set; }

        // Departamento al que pertenece ese puesto
        public Guid DepartmentId { get; set; }
    }
}