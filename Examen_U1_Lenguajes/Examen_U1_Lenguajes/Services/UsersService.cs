using AutoMapper;
using Examen_U1_Lenguajes.Constants;
using Examen_U1_Lenguajes.Database;
using Examen_U1_Lenguajes.Database.Entities;
using Examen_U1_Lenguajes.Dtos.Common;
using Examen_U1_Lenguajes.Dtos.JobTitles;
using Examen_U1_Lenguajes.Dtos.Users;
using Examen_U1_Lenguajes.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Examen_U1_Lenguajes.Services
{
    public class UsersService : IUsersService
    {
        private readonly ExamenContext _context;
        private readonly IMapper _mapper;

        public UsersService(ExamenContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        public async Task<ResponseDto<List<UserDto>>> GetUsersListAsync()
        {
            var userEntity = await _context.Users.ToListAsync();
            var userDtos = _mapper.Map<List<UserDto>>(userEntity);

            return new ResponseDto<List<UserDto>>
            {
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.RECORDS_FOUND,
                Data = userDtos
            };
        }

        public async Task<ResponseDto<UserDto>> GetUserByIdAsync(Guid id)
        {
            var userEntity = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (userEntity == null)
            {
                return new ResponseDto<UserDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.RECORD_NOT_FOUND
                };
            }

            var userDto = _mapper.Map<UserDto>(userEntity);

            return new ResponseDto<UserDto>
            {
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.RECORD_FOUND,
                Data = userDto
            };
        }

        public async Task<ResponseDto<UserDto>> CreateAsync(UserCreateDto dto)
        {
            var userEntity = _mapper.Map<UserEntity>(dto);

            _context.Users.Add(userEntity);

            await _context.SaveChangesAsync();

            var userDto = _mapper.Map<UserDto>(userEntity);

            return new ResponseDto<UserDto>
            {
                StatusCode = 201,
                Status = true,
                Message = MessagesConstant.CREATE_SUCCESS,
                Data = userDto
            };
        }

        public async Task<ResponseDto<UserDto>> EditAsync(UserEditDto dto, Guid id)
        {

            var userEntity = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (userEntity == null)
            {
                return new ResponseDto<UserDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.RECORD_NOT_FOUND
                };
            }

            _mapper.Map<UserEditDto, UserEntity>(dto, userEntity);

            _context.Users.Update(userEntity);

            await _context.SaveChangesAsync();

            var userDto = _mapper.Map<UserDto>(userEntity);

            return new ResponseDto<UserDto>
            {
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.UPDATE_SUCCESS,
                Data = userDto
            };
        }


        public async Task<ResponseDto<UserDto>> DeleteAsync(Guid id)
        {
            var userEntity = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (userEntity == null)
            {
                return new ResponseDto<UserDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.RECORD_NOT_FOUND
                };
            }

            _context.Users.Remove(userEntity);
            await _context.SaveChangesAsync();

            return new ResponseDto<UserDto>
            {
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.DELETE_SUCCESS
            };
        }
      
    }
}
