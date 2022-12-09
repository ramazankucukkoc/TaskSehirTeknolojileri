using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSehirTeknolojileri_Core.Utilities.Results;
using TaskSehirTeknolojileri_Data.DataAccess.Abstract;
using TaskSehirTeknolojileri_Data.DataAccess.Concrete;
using TaskSehirTeknolojileri_Data.Entities.Concrete;
using TaskSehirTeknolojileri_Data.Entities.Dtos;
using TaskSehirTeknolojileri_Service.Abstract;
using TaskSehirTeknolojileri_Service.Mappings.AutoMapper;
using TaskSehirTeknolojileri_Service.Utilities;

namespace TaskSehirTeknolojileri_Service.Concrete
{
    public class UserRefreshTokenManager:IRefreshTokenService
    {
        private readonly IUserRefreshTokenDal _userRefreshTokenDal;

        public UserRefreshTokenManager(IUserRefreshTokenDal userRefreshTokenDal)
        {
            _userRefreshTokenDal = userRefreshTokenDal;
        }

        public async Task<IDataResult<UserRefreshTokenDto>> AddAsync(UserRefreshTokenDto entity)
        {
            var refreshToken = ObjectMapper.Mapper.Map<UserRefreshToken>(entity);
            if (refreshToken != null)
            {
                await _userRefreshTokenDal.AddAsync(refreshToken);
                return new DataResult<UserRefreshTokenDto>(ResultStatus.Success, entity);
            }
            return new DataResult<UserRefreshTokenDto>(ResultStatus.Error, null);

        }

        public Task<IDataResult<int>> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<UserRefreshTokenDto>> DeleteAsync(UserRefreshTokenDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<UserRefreshTokenDto>>> GetAllNonDeletedAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<UserRefreshTokenDto>> GetByIdAsync(string id)
        {
            var refreshTokenDto = await _userRefreshTokenDal.GetAsync(rt => rt.UserId == id);
            var refreshToken = ObjectMapper.Mapper.Map<UserRefreshTokenDto>(refreshTokenDto);

            return new DataResult<UserRefreshTokenDto>(ResultStatus.Success, "", refreshToken);
        }

        public async Task<IDataResult<UserRefreshTokenDto>> GetRefreshTokenAsync(string refreshToken)
        {
            var refreshTokenDto = await _userRefreshTokenDal.GetAsync(rt =>rt.Code ==refreshToken);
            var refresh = ObjectMapper.Mapper.Map<UserRefreshTokenDto>(refreshTokenDto);
            return new DataResult<UserRefreshTokenDto>(ResultStatus.Success, "", refresh);
        }

        public Task<IDataResult<UserRefreshTokenDto>> UpdateAsync(UserRefreshTokenDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
