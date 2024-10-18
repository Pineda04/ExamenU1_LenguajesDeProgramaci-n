using AutoMapper;
using Examen_U1_Lenguajes.Constants;
using Examen_U1_Lenguajes.Database;
using Examen_U1_Lenguajes.Database.Entities;
using Examen_U1_Lenguajes.Dtos.Common;
using Examen_U1_Lenguajes.Dtos.JobTitles;
using Examen_U1_Lenguajes.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Examen_U1_Lenguajes.Services
{
    public class JobTitlesService : IJobTitlesService
    {
        private readonly ExamenContext _context;
        private readonly IMapper _mapper;

        public JobTitlesService(ExamenContext context, IMapper mapper)
        {
            this._mapper = mapper;
            this._context = context;
        }

        public async Task<ResponseDto<List<JobTitleDto>>> GetJobTitlesListAsync()
        {
            var jobsEntity = await _context.JobTitles.ToListAsync();
            var jobsDtos = _mapper.Map<List<JobTitleDto>>(jobsEntity);

            return new ResponseDto<List<JobTitleDto>>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.RECORDS_FOUND,
                Data = jobsDtos
            };
        }

        public async Task<ResponseDto<JobTitleDto>> GetJobTitleByIdAsync(Guid id)
        {
            var jobEntity = await _context.JobTitles.FirstOrDefaultAsync(j => j.Id == id);

            if(jobEntity == null){
                return new ResponseDto<JobTitleDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.RECORD_NOT_FOUND
                };
            }

            var jobDto = _mapper.Map<JobTitleDto>(jobEntity);

            return new ResponseDto<JobTitleDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.RECORD_FOUND,
                Data = jobDto
            };
        }

        public async Task<ResponseDto<JobTitleDto>> CreateAsync(JobTitleCreateDto dto)
        {
            var jobEntity = _mapper.Map<JobTitleEntity>(dto);

            _context.JobTitles.Add(jobEntity);

            await _context.SaveChangesAsync();

            var jobDto = _mapper.Map<JobTitleDto>(jobEntity);

            return new ResponseDto<JobTitleDto>{
                StatusCode = 201,
                Status = true,
                Message = MessagesConstant.CREATE_SUCCESS,
                Data = jobDto
            };
        }

        public async Task<ResponseDto<JobTitleDto>> EditAsync(JobTitleEditDto dto, Guid id)
        {
            var jobEntity = await _context.JobTitles.FirstOrDefaultAsync(j => j.Id == id);

            if(jobEntity == null){
                return new ResponseDto<JobTitleDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.RECORD_NOT_FOUND
                };
            }

            _mapper.Map<JobTitleEditDto, JobTitleEntity>(dto, jobEntity);

            _context.JobTitles.Update(jobEntity);

            await _context.SaveChangesAsync();

            var jobDto = _mapper.Map<JobTitleDto>(jobEntity);

            return new ResponseDto<JobTitleDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.UPDATE_SUCCESS,
                Data = jobDto
            };
        }

        public async Task<ResponseDto<JobTitleDto>> DeleteAsync(Guid id)
        {
            var jobEntity = await _context.JobTitles.FirstOrDefaultAsync(j => j.Id == id);

            if(jobEntity == null){
                return new ResponseDto<JobTitleDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.RECORD_NOT_FOUND
                };
            }

            _context.JobTitles.Remove(jobEntity);
            await _context.SaveChangesAsync();

            return new ResponseDto<JobTitleDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.DELETE_SUCCESS
            };
        }   
    }
}