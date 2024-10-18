using Examen_U1_Lenguajes.Dtos.Common;
using Examen_U1_Lenguajes.Dtos.Users;

namespace Examen_U1_Lenguajes.Services.Interfaces
{
    public interface IUsersService
    {
        Task<ResponseDto<List<UserDto>>> GetUsersListAsync();

        Task<ResponseDto<UserDto>> GetUserByIdAsync(Guid id);

        Task<ResponseDto<UserDto>> CreateAsync(UserCreateDto dto);

        Task<ResponseDto<UserDto>> EditAsync(UserEditDto dto, Guid id);

        Task<ResponseDto<UserDto>> DeleteAsync(Guid id);
    }
}
