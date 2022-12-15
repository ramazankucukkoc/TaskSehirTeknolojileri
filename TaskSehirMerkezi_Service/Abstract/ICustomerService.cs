using TaskSehirTeknolojileri_Core.Utilities.Results;
using TaskSehirTeknolojileri_Data.Entities.Dtos;

namespace TaskSehirTeknolojileri_Service.Abstract
{
    public interface ICustomerService
    {
        Task<IDataResult<List<CustomerDto>>> GetAllNonDeletedAsync();
        Task<IDataResult<CustomerDto>> DeleteAsync(CustomerDto entity);
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<CustomerDto>> AddAsync(CustomerDto entity);
        Task<IDataResult<CustomerDto>> UpdateAsync(CustomerDto entity);
    }
}
