using AutoMapper;
using Examen_U1_Lenguajes.Database.Entities;
using Examen_U1_Lenguajes.Dtos.Departments;
using Examen_U1_Lenguajes.Dtos.JobTitles;
using Examen_U1_Lenguajes.Dtos.PermissionTypes;

namespace Examen_U1_Lenguajes.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            MapsForJobTitles();
            MapsForDepartments();
            MapsForPermissionTypes();
        }

        private void MapsForPermissionTypes()
        {
            CreateMap<PermissionTypeEntity, PermissionTypeDto>();
            CreateMap<PermissionTypeCreateDto, PermissionTypeEntity>();
            CreateMap<PermissionTypeEditDto, PermissionTypeEntity>();
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