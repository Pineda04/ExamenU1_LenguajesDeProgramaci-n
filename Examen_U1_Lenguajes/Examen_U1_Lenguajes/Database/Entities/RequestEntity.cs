using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Examen_U1_Lenguajes.Database.Entities
{
    [Table("requests", Schema = "dbo")]
    public class RequestEntity : BaseEntity
    {
        // Id del usuario
        [StringLength(100)]
        [Column("user_id")]
        public string UserId { get; set; }

        // Id del tipo de permiso
        [Column("permission_type_id")]
        public Guid PermissionTypeId { get; set; }
        [ForeignKey(nameof(PermissionTypeId))]
        public virtual PermissionTypeEntity PermissionType { get; set; }

        // Fecha Inicio
        [Column("start_date")]
        public DateTime StartDate { get; set; }

        // Fecha fin
        [Column("end_date")]
        public DateTime EndDate { get; set; }

        // Motivo
        [StringLength(500)]
        [Required]
        [Column("reason")]
        public string Reason { get; set; }

        // Estado
        [Column("is_approved")]
        public Boolean IsApproved { get; set; }

        public virtual IdentityUser CreatedByUser { get; set; }
        public virtual IdentityUser UpdatedByUser { get; set; }
    }
}