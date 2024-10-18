using AutoMapper;
using Examen_U1_Lenguajes.Database.Entities;
using Examen_U1_Lenguajes.Dtos.Departments;
using Examen_U1_Lenguajes.Dtos.JobTitles;

namespace Examen_U1_Lenguajes.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            MapsForJobTitles();
            MapsForDepartments();
        }

        private void MapsForDepartments()
        {
            CreateMap<DepartmentEntity, DepartmentDto>();
            CreateMap<DepartmentCreateDto, DepartmentEntity>();
            CreateMap<DepartmentEditDto, DepartmentEntity>();
        }

        private void MapsForJobTitles()
        {
            CreateMap<JobTitleEntity, JobTitleDto>();
            CreateMap<JobTitleCreateDto, JobTitleEntity>();
            CreateMap<JobTitleEditDto, JobTitleEntity>();
        }
    }
}