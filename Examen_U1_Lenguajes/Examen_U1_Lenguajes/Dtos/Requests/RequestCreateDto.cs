using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_U1_Lenguajes.Dtos.Requests
{
    public class RequestCreateDto
    {
        // Usuario id
        public string UserId { get; set; }

        // Tipo permiso id
        public string PermissionTypeId { get; set; }

        // Fecha inicio
        public DateTime StartDate { get; set; }

        // Fecha fin
        public DateTime EndDate { get; set; }

        // Motivo
        [Display(Name = "motivo")]
        [StringLength(500, ErrorMessage = "El {0} de la solicitud tener menos de {1} caracteres.")]
        [Required(ErrorMessage = "El {0} de la solicitud es obligatorio.")]
        public string Reason { get; set; }

        // Estado
        public Boolean Is_Approved { get; set; }
    }
}