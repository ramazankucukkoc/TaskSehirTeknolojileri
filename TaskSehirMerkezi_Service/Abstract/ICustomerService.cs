using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSehirTeknolojileri_Data.Entities.Dtos;

namespace TaskSehirTeknolojileri_Service.Abstract
{
    public interface ICustomerService:IGenericService<CustomerDto>
    {
        //Task<IDataResult<List<CustomerDto>>> GetAllNonDeleted();
        //Task<IDataResult<CustomerDto>> DeleteAsync(int id);
        //Task<IDataResult<int>> CountAsync();
        //Task<IDataResult<CustomerDto>> AddAsync(CustomerDto entity);
        //Task<IDataResult<CustomerDto>> UpdateAsync(CustomerDto entity);
    }
}
