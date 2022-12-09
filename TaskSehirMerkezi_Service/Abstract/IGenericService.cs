using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSehirTeknolojileri_Core.Entities;
using TaskSehirTeknolojileri_Core.Utilities.Results;
namespace TaskSehirTeknolojileri_Service.Abstract
{
    public interface IGenericService<T>
   
    {
        Task<IDataResult<List<T>>> GetAllNonDeletedAsync();
        Task<IDataResult<T>> DeleteAsync(T entity);
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<T>> AddAsync(T entity);
        Task<IDataResult<T>> UpdateAsync(T entity);
    }
}
