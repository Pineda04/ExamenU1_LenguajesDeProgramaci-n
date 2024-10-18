using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen_U1_Lenguajes.Database.Entities
{
    [Table("departments", Schema = "dbo")]
    public class DepartmentEntity : BaseEntity
    {
        // Nombre del departamento
        [StringLength(75)]
        [Required]
        [Column("name")]
        public string Name { get; set; }

        public virtual IEnumerable<JobTitleEntity> JobTitles { get; set; }
    }
}