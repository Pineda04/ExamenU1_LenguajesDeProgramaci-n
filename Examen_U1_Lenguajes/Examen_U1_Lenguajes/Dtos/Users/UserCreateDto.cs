using System.ComponentModel.DataAnnotations;

namespace Examen_U1_Lenguajes.Dtos.Users
{
    public class UserCreateDto
    {

        [Display(Name = "nombre")]
        [StringLength(75, ErrorMessage = "El {0} del usuario debe tener menos de {1} caracteres.")]
        [Required(ErrorMessage = "El {0} de usuario es obligatorio.")]
        public string FirstName { get; set; }


        [Display(Name = "apellido")]
        [StringLength(75, ErrorMessage = "El {0} del usuario debe tener menos de {1} caracteres.")]
        [Required(ErrorMessage = "El {0} de usuario es obligatorio.")]
        public string LastName { get; set; }


        public Guid JobTitleId { get; set; }

        public DateTime DateEntry { get; set; }

        [Display(Name ="identidad")]
        [StringLength(13)]
        [Required]
        public string Identity { get; set; }

        [Display(Name ="numero de telefono")]
        [StringLength(8)]
        public string PhoneNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public Boolean Gender { get; set; }

    }
}
