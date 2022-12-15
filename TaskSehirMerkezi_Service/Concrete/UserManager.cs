using Microsoft.AspNetCore.Identity;
using TaskSehirTeknolojileri_Core.Utilities.Results;
using TaskSehirTeknolojileri_Data.DataAccess.Abstract;
using TaskSehirTeknolojileri_Data.Entities.Concrete;
using TaskSehirTeknolojileri_Data.Entities.Dtos;
using TaskSehirTeknolojileri_Service.Abstract;
using TaskSehirTeknolojileri_Service.Mappings.AutoMapper;

namespace TaskSehirTeknolojileri_Service.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task AddAsync(User user)
        {
            await _userDal.AddAsync(user);
        }

        public async Task<IDataResult<User>> GetByEmail(string email)
        {
            var user = await _userDal.GetAsync(x => x.Email == email);
            return new DataResult<User>(ResultStatus.Success, user);
        }

        public async Task<IDataResult<List<OperationClaim>>> GetOperationClaims(User user)
        {
            var roles = await _userDal.GetClaims(user);
            return new DataResult<List<OperationClaim>>(ResultStatus.Success, roles);
        }
        
    }
}
