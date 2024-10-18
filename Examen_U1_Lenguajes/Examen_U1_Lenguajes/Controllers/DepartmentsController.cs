using Examen_U1_Lenguajes.Dtos.Common;
using Examen_U1_Lenguajes.Dtos.Departments;
using Examen_U1_Lenguajes.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Examen_U1_Lenguajes.Controllers
{
    [ApiController]
    [Route("api/departments")]
    
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentsService _departmentsService;

        public DepartmentsController(IDepartmentsService departmentsService)
        {
            this._departmentsService = departmentsService;
        }

        // Traer todos
        [HttpGet]
        public async Task<ActionResult<ResponseDto<DepartmentDto>>> GetAll(){
            var response = await _departmentsService.GetDepartmentsListAsync();

            return StatusCode(response.StatusCode, response);
        }

        // Traer por id
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<DepartmentDto>>> Get(Guid id){
            var response = await _departmentsService.GetDepartmentByIdAsync(id);

            return StatusCode(response.StatusCode, response);
        }

        // Crear
        [HttpPost]
        public async Task<ActionResult<ResponseDto<DepartmentDto>>> Create(DepartmentCreateDto dto){
            var response = await _departmentsService.CreateAsync(dto);

            return StatusCode(response.StatusCode, response);
        }

        // Editar
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<DepartmentDto>>> Edit(DepartmentEditDto dto, Guid id){
            var response = await _departmentsService.EditAsync(dto, id);

            return StatusCode(response.StatusCode, response);
        }
        
        // Eliminar
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto<DepartmentDto>>> Delete(Guid id){
            var response = await _departmentsService.DeleteAsync(id);

            return StatusCode(response.StatusCode, response);
        }
    }
}