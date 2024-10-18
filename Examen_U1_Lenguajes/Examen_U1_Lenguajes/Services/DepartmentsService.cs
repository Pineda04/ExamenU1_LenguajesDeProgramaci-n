using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Examen_U1_Lenguajes.Constants;
using Examen_U1_Lenguajes.Database;
using Examen_U1_Lenguajes.Database.Entities;
using Examen_U1_Lenguajes.Dtos.Common;
using Examen_U1_Lenguajes.Dtos.Departments;
using Examen_U1_Lenguajes.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Examen_U1_Lenguajes.Services
{
    public class DepartmentsService : IDepartmentsService
    {
        private readonly ExamenContext _context;
        private readonly IMapper _mapper;

        public DepartmentsService(ExamenContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<ResponseDto<List<DepartmentDto>>> GetDepartmentsListAsync()
        {
            var departmentsEntity = await _context.Departments.ToListAsync();
            var departmentsDtos = _mapper.Map<List<DepartmentDto>>(departmentsEntity);

            return new ResponseDto<List<DepartmentDto>>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.RECORDS_FOUND,
                Data = departmentsDtos
            };
        }

        public async Task<ResponseDto<DepartmentDto>> GetDepartmentByIdAsync(Guid id)
        {
            var departmentEntity = await _context.Departments.FirstOrDefaultAsync(d => d.Id == id);

            if(departmentEntity == null){
                return new ResponseDto<DepartmentDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.RECORD_NOT_FOUND
                };
            }

            var departmentDto = _mapper.Map<DepartmentDto>(departmentEntity);

            return new ResponseDto<DepartmentDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.RECORD_FOUND,
                Data = departmentDto
            };
        }

        public async Task<ResponseDto<DepartmentDto>> CreateAsync(DepartmentCreateDto dto)
        {
            var departmentEntity = _mapper.Map<DepartmentEntity>(dto);

            _context.Departments.Add(departmentEntity);

            await _context.SaveChangesAsync();

            var departmentDto = _mapper.Map<DepartmentDto>(departmentEntity);

            return new ResponseDto<DepartmentDto>{
                StatusCode = 201,
                Status = true,
                Message = MessagesConstant.CREATE_SUCCESS,
                Data = departmentDto
            };
        }

        public async Task<ResponseDto<DepartmentDto>> EditAsync(DepartmentEditDto dto, Guid id)
        {
            var departmentEntity = await _context.Departments.FirstOrDefaultAsync(d => d.Id == id);

            if(departmentEntity == null){
                return new ResponseDto<DepartmentDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.RECORD_NOT_FOUND
                };
            }

            _mapper.Map<DepartmentEditDto, DepartmentEntity>(dto, departmentEntity);

            _context.Departments.Update(departmentEntity);

            await _context.SaveChangesAsync();

            var departmentDto = _mapper.Map<DepartmentDto>(departmentEntity);

            return new ResponseDto<DepartmentDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.UPDATE_SUCCESS,
                Data = departmentDto
            };
        }

        public async Task<ResponseDto<DepartmentDto>> DeleteAsync(Guid id)
        {
            var departmentEntity = await _context.Departments.FirstOrDefaultAsync(d => d.Id == id);

            if(departmentEntity == null){
                return new ResponseDto<DepartmentDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.RECORD_NOT_FOUND
                };
            }

            _context.Departments.Remove(departmentEntity);
            await _context.SaveChangesAsync();

            return new ResponseDto<DepartmentDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.DELETE_SUCCESS
            };
        }
    }
}