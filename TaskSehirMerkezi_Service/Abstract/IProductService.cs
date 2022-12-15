using TaskSehirTeknolojileri_Core.Utilities.Results;
using TaskSehirTeknolojileri_Data.Entities.Dtos;

namespace TaskSehirTeknolojileri_Service.Abstract
{
    public interface IProductService
    {
        Task<IDataResult<List<ProductDto>>> GetAllNonDeletedAsync();
        Task<IDataResult<List<ProductWithCategoryDto>>> GetProductsWithCategory();
        Task<IDataResult<ProductDto>> DeleteAsync(ProductDto entity);
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<ProductDto>> AddAsync(ProductDto entity);
        Task<IDataResult<ProductDto>> UpdateAsync(ProductDto entity);
    }
}
