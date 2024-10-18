using Examen_U1_Lenguajes.Dtos.Common;
using Examen_U1_Lenguajes.Dtos.Departments;

namespace Examen_U1_Lenguajes.Services.Interfaces
{
    public interface IDepartmentsService
    {
        Task<ResponseDto<List<DepartmentDto>>> GetDepartmentsListAsync();

        Task<ResponseDto<DepartmentDto>> GetDepartmentByIdAsync(Guid id);

        Task<ResponseDto<DepartmentDto>> CreateAsync(DepartmentCreateDto dto);

        Task<ResponseDto<DepartmentDto>> EditAsync(DepartmentEditDto dto, Guid id);

        Task<ResponseDto<DepartmentDto>> DeleteAsync(Guid id);
    }
}