using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examen_U1_Lenguajes.Dtos.Common;
using Examen_U1_Lenguajes.Dtos.Requests;
using Examen_U1_Lenguajes.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Examen_U1_Lenguajes.Controllers
{
    [ApiController]
    [Route("api/requests")]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestsService _requestsService;

        public RequestsController(IRequestsService requestsService)
        {
            this._requestsService = requestsService;
        }

        // Traer todos
        [HttpGet]
        public async Task<ActionResult<ResponseDto<RequestDto>>> GetAll(){
            var response = await _requestsService.GetRequestsListAsync();

            return StatusCode(response.StatusCode, response);
        }

        // Traer por id
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<RequestDto>>> Get(Guid id){
            var response = await _requestsService.GetRequestByIdAsync(id);

            return StatusCode(response.StatusCode, response);
        }

        // Crear
        [HttpPost]
        public async Task<ActionResult<ResponseDto<RequestDto>>> Create(RequestCreateDto dto){
            var response = await _requestsService.CreateAsync(dto);

            return StatusCode(response.StatusCode, response);
        }

        // Editar
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<RequestDto>>> Edit(RequestEditDto dto, Guid id){
            var response = await _requestsService.EditAsync(dto, id);

            return StatusCode(response.StatusCode, response);
        }
        
        // Eliminar
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto<RequestDto>>> Delete(Guid id){
            var response = await _requestsService.DeleteAsync(id);

            return StatusCode(response.StatusCode, response);
        }
    }
}