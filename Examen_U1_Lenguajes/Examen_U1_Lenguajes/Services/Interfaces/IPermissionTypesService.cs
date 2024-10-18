using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examen_U1_Lenguajes.Dtos.Common;
using Examen_U1_Lenguajes.Dtos.PermissionTypes;

namespace Examen_U1_Lenguajes.Services.Interfaces
{
    public interface IPermissionTypesService
    {
        Task<ResponseDto<List<PermissionTypeDto>>> GetPermissionTypesListAsync();

        Task<ResponseDto<PermissionTypeDto>> GetPermissionTypeByIdAsync(Guid id);

        Task<ResponseDto<PermissionTypeDto>> CreateAsync(PermissionTypeCreateDto dto);

        Task<ResponseDto<PermissionTypeDto>> EditAsync(PermissionTypeEditDto dto, Guid id);

        Task<ResponseDto<PermissionTypeDto>> DeleteAsync(Guid id);
    }
}