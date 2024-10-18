using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen_U1_Lenguajes.Database.Entities
{
    public class BaseEntity
    {
        // Id
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        // Creado por
        [StringLength(250)]
        [Column("created_by")]
        public string CreatedBy { get; set; }

        // Fecha de creación
        [Column("created_date")]
        public DateTime CreatedDate { get; set; }

        // Actualizado por
        [StringLength(250)]
        [Column("updated_by")]
        public string UpdatedBy { get; set; }

        // Fecha de actualización
        [Column("updated_date")]
        public DateTime UpdatedDate { get; set; }
    }
}