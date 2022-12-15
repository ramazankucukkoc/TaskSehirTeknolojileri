using TaskSehirTeknolojileri_Core.Utilities.Results;
using TaskSehirTeknolojileri_Data.DataAccess.Abstract;
using TaskSehirTeknolojileri_Data.Entities.Concrete;
using TaskSehirTeknolojileri_Data.Entities.Dtos;
using TaskSehirTeknolojileri_Service.Abstract;
using TaskSehirTeknolojileri_Service.Mappings.AutoMapper;
using TaskSehirTeknolojileri_Service.Utilities;

namespace TaskSehirTeknolojileri_Service.Concrete
{

    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public async Task<IDataResult<CategoryDto>> AddAsync(CategoryDto entity)
        {
            var category = ObjectMapper.Mapper.Map<Category>(entity);
            category.CreatedDate = DateTime.Now;
            await _categoryDal.AddAsync(category);
            return new DataResult<CategoryDto>(ResultStatus.Success, Messages.Category.Add(category.Name), entity);
        }

        public Task<IDataResult<int>> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CategoryDto>> DeleteAsync(CategoryDto entity)
        {
            throw new NotImplementedException();
        }
        public Task<IDataResult<List<CategoryDto>>> GetAllNonDeletedAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CategoryDto>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CategoryDto>> UpdateAsync(CategoryDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
