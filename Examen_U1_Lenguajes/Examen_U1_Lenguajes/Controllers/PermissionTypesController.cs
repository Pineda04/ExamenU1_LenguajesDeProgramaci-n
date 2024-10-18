using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examen_U1_Lenguajes.Dtos.Common;
using Examen_U1_Lenguajes.Dtos.PermissionTypes;
using Examen_U1_Lenguajes.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Examen_U1_Lenguajes.Controllers
{
    [ApiController]
    [Route("api/permission_types")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class PermissionTypesController : ControllerBase
    {
        private readonly IPermissionTypesService _permissionTypesService;

        public PermissionTypesController(IPermissionTypesService permissionTypesService)
        {
            this._permissionTypesService = permissionTypesService;
        }

        // Traer todos
        [HttpGet]
        public async Task<ActionResult<ResponseDto<PermissionTypeDto>>> GetAll(){
            var response = await _permissionTypesService.GetPermissionTypesListAsync();

            return StatusCode(response.StatusCode, response);
        }

        // Traer por id
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<PermissionTypeDto>>> Get(Guid id){
            var response = await _permissionTypesService.GetPermissionTypeByIdAsync(id);

            return StatusCode(response.StatusCode, response);
        }

        // Crear
        [HttpPost]
        public async Task<ActionResult<ResponseDto<PermissionTypeDto>>> Create(PermissionTypeCreateDto dto){
            var response = await _permissionTypesService.CreateAsync(dto);

            return StatusCode(response.StatusCode, response);
        }

        // Editar
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<PermissionTypeDto>>> Edit(PermissionTypeEditDto dto, Guid id){
            var response = await _permissionTypesService.EditAsync(dto, id);

            return StatusCode(response.StatusCode, response);
        }
        
        // Eliminar
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto<PermissionTypeDto>>> Delete(Guid id){
            var response = await _permissionTypesService.DeleteAsync(id);

            return StatusCode(response.StatusCode, response);
        }
    }
}