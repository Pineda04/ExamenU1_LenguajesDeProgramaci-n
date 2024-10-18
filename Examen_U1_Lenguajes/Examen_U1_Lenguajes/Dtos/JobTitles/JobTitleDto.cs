using Examen_U1_Lenguajes.Dtos.Departments;

namespace Examen_U1_Lenguajes.Dtos.JobTitles
{
    public class JobTitleDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual DepartmentDto Department { get; set; }
    }
}