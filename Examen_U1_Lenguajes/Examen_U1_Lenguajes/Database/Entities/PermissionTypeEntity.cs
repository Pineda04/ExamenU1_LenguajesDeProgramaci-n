using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen_U1_Lenguajes.Database.Entities
{
    [Table("permission_types", Schema = "dbo")]
    public class PermissionTypeEntity : BaseEntity
    {
        // Nombre del tipo de permiso
        [StringLength(150)]
        [Required]
        [Column("name")]
        public string Name { get; set; }

        // public virtual IEnumerable<ResquestEntity> Resquests { get; set; }
    }
}