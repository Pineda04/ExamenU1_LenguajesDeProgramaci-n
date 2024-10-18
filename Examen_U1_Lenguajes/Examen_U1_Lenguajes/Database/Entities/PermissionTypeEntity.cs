using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

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

        public virtual IEnumerable<RequestEntity> Requests { get; set; }

        public virtual IdentityUser CreatedByUser { get; set; }
        public virtual IdentityUser UpdatedByUser { get; set; }
    }
}