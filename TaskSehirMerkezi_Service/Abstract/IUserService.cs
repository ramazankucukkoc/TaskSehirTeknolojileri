using TaskSehirTeknolojileri_Core.Utilities.Results;
using TaskSehirTeknolojileri_Data.Entities.Concrete;
using TaskSehirTeknolojileri_Data.Entities.Dtos;

namespace TaskSehirTeknolojileri_Service.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<List<OperationClaim>>> GetOperationClaims(User user);
        Task AddAsync(User user);
        Task<IDataResult<User>> GetByEmail(string email);


    }
}
