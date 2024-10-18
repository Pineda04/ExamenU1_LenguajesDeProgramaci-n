using Examen_U1_Lenguajes.Dtos.Common;
using Examen_U1_Lenguajes.Dtos.Departments;
using Examen_U1_Lenguajes.Dtos.Users;
using Examen_U1_Lenguajes.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examen_U1_Lenguajes.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        // Traer todos
        [HttpGet]
        public async Task<ActionResult<ResponseDto<UserDto>>> GetAll()
        {
            var response = await _usersService.GetUsersListAsync();

            return StatusCode(response.StatusCode, response);
        }

        // Traer por id
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<UserDto>>> Get(Guid id)
        {
            var response = await _usersService.GetUserByIdAsync(id);

            return StatusCode(response.StatusCode, response);
        }

        // Crear
        [HttpPost]
        public async Task<ActionResult<ResponseDto<UserDto>>> Create(UserCreateDto dto)
        {
            var response = await _usersService.CreateAsync(dto);

            return StatusCode(response.StatusCode, response);
        }

        // Editar
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<DepartmentDto>>> Edit(UserEditDto dto, Guid id)
        {
            var response = await _usersService.EditAsync(dto, id);

            return StatusCode(response.StatusCode, response);
        }

        // Eliminar
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto<UserDto>>> Delete(Guid id)
        {
            var response = await _usersService.DeleteAsync(id);

            return StatusCode(response.StatusCode, response);
        }
    }
}
