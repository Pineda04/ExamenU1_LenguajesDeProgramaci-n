using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Examen_U1_Lenguajes.Constants;
using Examen_U1_Lenguajes.Database;
using Examen_U1_Lenguajes.Database.Entities;
using Examen_U1_Lenguajes.Dtos.Common;
using Examen_U1_Lenguajes.Dtos.PermissionTypes;
using Examen_U1_Lenguajes.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Examen_U1_Lenguajes.Services
{
    public class PermissionTypesService : IPermissionTypesService
    {
        private readonly ExamenContext _context;
        private readonly IMapper _mapper;

        public PermissionTypesService(ExamenContext context, IMapper mapper)
        {
            this._mapper = mapper;
            this._context = context;
        }

        public async Task<ResponseDto<List<PermissionTypeDto>>> GetPermissionTypesListAsync()
        {
            var permissionsEntity = await _context.Permissions.ToListAsync();
            var permissionsDtos = _mapper.Map<List<PermissionTypeDto>>(permissionsEntity);

            return new ResponseDto<List<PermissionTypeDto>>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.RECORDS_FOUND,
                Data = permissionsDtos
            };
        }

        public async Task<ResponseDto<PermissionTypeDto>> GetPermissionTypeByIdAsync(Guid id)
        {
            var permissionsEntity = await _context.Permissions.FirstOrDefaultAsync(p => p.Id == id);

            if(permissionsEntity == null){
                return new ResponseDto<PermissionTypeDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.RECORD_NOT_FOUND
                };
            }

            var permisisonsDto = _mapper.Map<PermissionTypeDto>(permissionsEntity);

            return new ResponseDto<PermissionTypeDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.RECORD_FOUND,
                Data = permisisonsDto
            };
        }

        public async Task<ResponseDto<PermissionTypeDto>> CreateAsync(PermissionTypeCreateDto dto)
        {
            var permissionEntity = _mapper.Map<PermissionTypeEntity>(dto);

            _context.Permissions.Add(permissionEntity);

            await _context.SaveChangesAsync();

            var permissionDto = _mapper.Map<PermissionTypeDto>(permissionEntity);

            return new ResponseDto<PermissionTypeDto>{
                StatusCode = 201,
                Status = true,
                Message = MessagesConstant.CREATE_SUCCESS,
                Data = permissionDto
            };
        }

        public async Task<ResponseDto<PermissionTypeDto>> EditAsync(PermissionTypeEditDto dto, Guid id)
        {
            var permissionEntity = await _context.Permissions.FirstOrDefaultAsync(p => p.Id == id);

            if(permissionEntity == null){
                return new ResponseDto<PermissionTypeDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.RECORD_NOT_FOUND
                };
            }

            _mapper.Map<PermissionTypeEditDto, PermissionTypeEntity>(dto, permissionEntity);

            _context.Permissions.Update(permissionEntity);

            await _context.SaveChangesAsync();

            var permissionDto = _mapper.Map<PermissionTypeDto>(permissionEntity);

            return new ResponseDto<PermissionTypeDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.UPDATE_SUCCESS,
                Data = permissionDto
            };
        }

        public async Task<ResponseDto<PermissionTypeDto>> DeleteAsync(Guid id)
        {
            var permissionEntity = await _context.Permissions.FirstOrDefaultAsync(p => p.Id == id);

            if(permissionEntity == null){
                return new ResponseDto<PermissionTypeDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.RECORD_NOT_FOUND
                };
            }

            _context.Permissions.Remove(permissionEntity);
            await _context.SaveChangesAsync();

            return new ResponseDto<PermissionTypeDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.DELETE_SUCCESS
            };
        }
    }
}