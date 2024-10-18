using Examen_U1_Lenguajes.Dtos.Common;
using Examen_U1_Lenguajes.Dtos.JobTitles;

namespace Examen_U1_Lenguajes.Services.Interfaces
{
    public interface IJobTitlesService
    {
        Task<ResponseDto<List<JobTitleDto>>> GetJobTitlesListAsync();

        Task<ResponseDto<JobTitleDto>> GetJobTitleByIdAsync(Guid id);

        Task<ResponseDto<JobTitleDto>> CreateAsync(JobTitleCreateDto dto);

        Task<ResponseDto<JobTitleDto>> EditAsync(JobTitleEditDto dto, Guid id);

        Task<ResponseDto<JobTitleDto>> DeleteAsync(Guid id);
    }
}