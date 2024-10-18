using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Examen_U1_Lenguajes.Constants;
using Examen_U1_Lenguajes.Database;
using Examen_U1_Lenguajes.Database.Entities;
using Examen_U1_Lenguajes.Dtos.Common;
using Examen_U1_Lenguajes.Dtos.Requests;
using Examen_U1_Lenguajes.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Examen_U1_Lenguajes.Services
{
    public class RequestsService : IRequestsService
    {
        private readonly ExamenContext _context;
        private readonly IMapper _mapper;

        public RequestsService(ExamenContext context, IMapper mapper)
        {
            this._mapper = mapper;
            this._context = context;
        }

        public async Task<ResponseDto<List<RequestDto>>> GetRequestsListAsync()
        {
            var requestEntity = await _context.Requests.ToListAsync();
            var requestDtos = _mapper.Map<List<RequestDto>>(requestEntity);

            return new ResponseDto<List<RequestDto>>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.RECORDS_FOUND,
                Data = requestDtos
            };
        }

        public async Task<ResponseDto<RequestDto>> GetRequestByIdAsync(Guid id)
        {
            var requestEntity = await _context.Requests.FirstOrDefaultAsync(r => r.Id == id);

            if(requestEntity == null){
                return new ResponseDto<RequestDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.RECORD_NOT_FOUND
                };
            }

            var requestDto = _mapper.Map<RequestDto>(requestEntity);

            return new ResponseDto<RequestDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.RECORD_FOUND,
                Data = requestDto
            };
        }

        public async Task<ResponseDto<RequestDto>> CreateAsync(RequestCreateDto dto)
        {
            var requestEntity = _mapper.Map<RequestEntity>(dto);

            _context.Requests.Add(requestEntity);

            await _context.SaveChangesAsync();

            var requestDto = _mapper.Map<RequestDto>(requestEntity);

            return new ResponseDto<RequestDto>{
                StatusCode = 201,
                Status = true,
                Message = MessagesConstant.CREATE_SUCCESS,
                Data = requestDto
            };
        }

        public async Task<ResponseDto<RequestDto>> EditAsync(RequestEditDto dto, Guid id)
        {
            var requestEntity = await _context.Requests.FirstOrDefaultAsync(r => r.Id == id);

            if(requestEntity == null){
                return new ResponseDto<RequestDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.RECORD_NOT_FOUND
                };
            }

            _mapper.Map<RequestEditDto, RequestEntity>(dto, requestEntity);

            _context.Requests.Update(requestEntity);

            await _context.SaveChangesAsync();

            var requestDto = _mapper.Map<RequestDto>(requestEntity);

            return new ResponseDto<RequestDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.UPDATE_SUCCESS,
                Data = requestDto
            };
        }

        public async Task<ResponseDto<RequestDto>> DeleteAsync(Guid id)
        {
            var requestEntity = await _context.Requests.FirstOrDefaultAsync(r => r.Id == id);

            if(requestEntity == null){
                return new ResponseDto<RequestDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.RECORD_NOT_FOUND
                };
            }

            _context.Requests.Remove(requestEntity);
            await _context.SaveChangesAsync();

            return new ResponseDto<RequestDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.DELETE_SUCCESS
            };
        }      
    }
}