using TaskSehirTeknolojileri_Core.Utilities.Results;
using TaskSehirTeknolojileri_Data.Entities.Dtos;

namespace TaskSehirTeknolojileri_Service.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<List<CategoryDto>>> GetAllNonDeletedAsync();
        Task<IDataResult<CategoryDto>> DeleteAsync(CategoryDto entity);
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<CategoryDto>> AddAsync(CategoryDto entity);
        Task<IDataResult<CategoryDto>> UpdateAsync(CategoryDto entity);
    }
}
