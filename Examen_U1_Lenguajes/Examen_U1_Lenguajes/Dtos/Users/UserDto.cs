using Examen_U1_Lenguajes.Dtos.Departments;
using Examen_U1_Lenguajes.Dtos.JobTitles;

namespace Examen_U1_Lenguajes.Dtos.Users
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual JobTitleDto JobTitle { get; set; }

        public DateTime DateEntry { get; set; }

        public string Identity { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public Boolean Gender { get; set; }
    }
}
