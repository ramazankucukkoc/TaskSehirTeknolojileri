using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSehirTeknolojileri_Core.Utilities.Results;
using TaskSehirTeknolojileri_Data.Entities.Dtos;

namespace TaskSehirTeknolojileri_Service.Abstract
{
    public interface IProductService:IGenericService<ProductDto>
    {
        //Task<IDataResult<List<ProductDto>>>GetAllNonDeleted();
        Task<IDataResult<List<ProductWithCategoryDto>>> GetProductsWithCategory();
        //Task<IDataResult<ProductDto>>DeleteAsync(int id);
        //Task<IDataResult<int>> CountAsync();
        //Task<IDataResult<ProductDto>> AddAsync(ProductDto entity);
        //Task<IDataResult<ProductDto>> UpdateAsync(ProductDto entity);
    }
}
