using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen_U1_Lenguajes.Database.Entities
{
    public class UserEntity : BaseEntity
    {
        [StringLength(75)]
        [Required]
        [Column("first_name")]
        public string FirstName { get; set; }
       
        [StringLength(75)]
        [Required]
        [Column("last_name")]
        public string LastName { get; set; }

        [Column("job_title_id")]
        public Guid JobTitleId { get; set; }
        [ForeignKey(nameof(JobTitleId))]
        public virtual JobTitleEntity JobTitle { get; set; }

        [Column("date_entry")]
        public DateTime DateEntry { get; set; }

        [StringLength(13)]
        [Required]
        [Column("identity")]
        public string Identity { get; set; }

        [StringLength(8)]
        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        [Column("birth_date")]
        [Required]
        public DateTime BirthDate { get; set; }

        [Column("gender")]
        [Required]
        public Boolean Gender { get; set; }
    }
}
