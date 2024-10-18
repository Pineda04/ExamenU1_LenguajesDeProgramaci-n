using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examen_U1_Lenguajes.Dtos.Common;
using Examen_U1_Lenguajes.Dtos.Requests;

namespace Examen_U1_Lenguajes.Services.Interfaces
{
    public interface IRequestsService
    {
        Task<ResponseDto<List<RequestDto>>> GetRequestsListAsync();

        Task<ResponseDto<RequestDto>> GetRequestByIdAsync(Guid id);

        Task<ResponseDto<RequestDto>> CreateAsync(RequestCreateDto dto);

        Task<ResponseDto<RequestDto>> EditAsync(RequestEditDto dto, Guid id);

        Task<ResponseDto<RequestDto>> DeleteAsync(Guid id);
    }
}