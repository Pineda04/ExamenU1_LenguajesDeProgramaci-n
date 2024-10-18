using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examen_U1_Lenguajes.Dtos.Common;
using Examen_U1_Lenguajes.Dtos.JobTitles;
using Examen_U1_Lenguajes.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Examen_U1_Lenguajes.Controllers
{
    [ApiController]
    [Route("api/job_titles")]
    public class JobTitlesController : ControllerBase
    {
        private readonly IJobTitlesService _jobTitlesService;

        public JobTitlesController(IJobTitlesService jobTitlesService)
        {
            this._jobTitlesService = jobTitlesService;
        }

        // Traer todos
        [HttpGet]
        public async Task<ActionResult<ResponseDto<JobTitleDto>>> GetAll(){
            var response = await _jobTitlesService.GetJobTitlesListAsync();

            return StatusCode(response.StatusCode, response);
        }

        // Traer por id
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<JobTitleDto>>> Get(Guid id){
            var response = await _jobTitlesService.GetJobTitleByIdAsync(id);

            return StatusCode(response.StatusCode, response);
        }

        // Crear
        [HttpPost]
        public async Task<ActionResult<ResponseDto<JobTitleDto>>> Create(JobTitleCreateDto dto){
            var response = await _jobTitlesService.CreateAsync(dto);

            return StatusCode(response.StatusCode, response);
        }

        // Editar
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<JobTitleDto>>> Edit(JobTitleEditDto dto, Guid id){
            var response = await _jobTitlesService.EditAsync(dto, id);

            return StatusCode(response.StatusCode, response);
        }
        
        // Eliminar
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto<JobTitleDto>>> Delete(Guid id){
            var response = await _jobTitlesService.DeleteAsync(id);

            return StatusCode(response.StatusCode, response);
        }
    }
}