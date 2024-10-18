using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examen_U1_Lenguajes.Dtos.Auth;
using Examen_U1_Lenguajes.Dtos.Common;

namespace Examen_U1_Lenguajes.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseDto<LoginResponseDto>> LoginAsync(LoginDto dto);
    }
}