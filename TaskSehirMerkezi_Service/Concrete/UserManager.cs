using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSehirTeknolojileri_Core.Utilities.Results;
using TaskSehirTeknolojileri_Data.Entities.Concrete;
using TaskSehirTeknolojileri_Data.Entities.Dtos;
using TaskSehirTeknolojileri_Service.Abstract;
using TaskSehirTeknolojileri_Service.Mappings.AutoMapper;

namespace TaskSehirTeknolojileri_Service.Concrete
{
    public class UserManager : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserManager(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IDataResult<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto)
        {
            var user = new User { Email = createUserDto.Email, UserName = createUserDto.UserName };

            var result = await _userManager.CreateAsync(user, createUserDto.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();
                return new DataResult<UserAppDto>(ResultStatus.Error, $"{errors}", null);
            }
            return new DataResult<UserAppDto>(ResultStatus.Success, ObjectMapper.Mapper.Map<UserAppDto>(user));

        }
        public async Task<IDataResult<UserAppDto>> GetUserAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user ==null)
            {
                return new DataResult<UserAppDto>(ResultStatus.Error, "User not found", null);
            }
            return new DataResult<UserAppDto>(ResultStatus.Success, ObjectMapper.Mapper.Map<UserAppDto>(user));
        }
    }
}
