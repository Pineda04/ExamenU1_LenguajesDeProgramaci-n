using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen_U1_Lenguajes.Database.Entities
{
    [Table("job_titles", Schema = "dbo")]
    public class JobTitleEntity : BaseEntity
    {
        // Nombre del puesto
        [StringLength(75)]
        [Required]
        [Column("name")]
        public string Name { get; set; }

        // Id del departamento
        [Column("department_id")]
        public Guid DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        public virtual DepartmentEntity Department { get; set; }
    }
}