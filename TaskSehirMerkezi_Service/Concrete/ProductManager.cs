using Microsoft.AspNetCore.Authorization;
using System.Data;
using TaskSehirTeknolojileri_Core.Utilities.Results;
using TaskSehirTeknolojileri_Data.DataAccess.Abstract;
using TaskSehirTeknolojileri_Data.Entities.Concrete;
using TaskSehirTeknolojileri_Data.Entities.Dtos;
using TaskSehirTeknolojileri_Service.Abstract;
using TaskSehirTeknolojileri_Service.BusinessAspect;
using TaskSehirTeknolojileri_Service.Mappings.AutoMapper;
using TaskSehirTeknolojileri_Service.Utilities;

namespace TaskSehirTeknolojileri_Service.Concrete
{

    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [SecuredOperation("Admin")]
        //[CacheAspect(duration: 10)]
        public async Task<IDataResult<List<ProductWithCategoryDto>>> GetProductsWithCategory()
        {
            var products = _productDal.ProductWithCategory(x => !x.IsDeleted).Result.Select(x => new ProductWithCategoryDto
            {
                Id = x.Id,
                Name = x.Name,
                Brand = x.Brand,
                CategoryId = x.CategoryId,
                Description = x.Description,
                CategoryName = x.Category.Name,
                Stock = x.Stock,
                UnitPrice = x.UnitPrice
            }).ToList();
            return new DataResult<List<ProductWithCategoryDto>>(ResultStatus.Success, "", products);
        }

        public async Task<IDataResult<List<ProductDto>>> GetAllNonDeletedAsync()
        {
            var getallProduct = await _productDal.GetAllAsync(p => !p.IsDeleted);
            if (getallProduct.Count > -1)
            {
                var getAllNonDeleted = ObjectMapper.Mapper.Map<List<ProductDto>>(getallProduct);
                return new DataResult<List<ProductDto>>(ResultStatus.Success, getAllNonDeleted);
            }
            return new DataResult<List<ProductDto>>(ResultStatus.Error, Messages.Product.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<ProductDto>> DeleteAsync(ProductDto entity)
        {
            var product = await _productDal.GetAsync(p => p.Id == entity.Id);
            if (product != null)
            {
                product.IsDeleted = true;
                product.ModifiedDate = DateTime.Now;
                await _productDal.UpdateAsync(product);
                return new DataResult<ProductDto>(ResultStatus.Success, Messages.Product.Delete(product.Name), entity);
            }
            return new DataResult<ProductDto>(ResultStatus.Error, Messages.Product.NonDelete(product.Name), null);
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var productCount = await _productDal.CountAsync();
            if (productCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, Messages.Product.Count(productCount), productCount);
            }
            return new DataResult<int>(ResultStatus.Error, Messages.Product.Count(productCount), -1);
        }

        public async Task<IDataResult<ProductDto>> AddAsync(ProductDto entity)
        {
            var product = ObjectMapper.Mapper.Map<Product>(entity);
            if (product != null)
            {
                product.CreatedDate = DateTime.Now;
                await _productDal.AddAsync(product);
                return new DataResult<ProductDto>(ResultStatus.Success, Messages.Product.Add(product.Name), entity);
            }
            return new DataResult<ProductDto>(ResultStatus.Error, Messages.Product.NotAdd(product.Name), null);
        }

        public async Task<IDataResult<ProductDto>> UpdateAsync(ProductDto entity)
        {
            var oldProduct = await _productDal.GetAsync(p => p.Id == entity.Id);
            if (entity != null)
            {
                var product = ObjectMapper.Mapper.Map<ProductDto, Product>(entity, oldProduct);
                product.ModifiedDate = DateTime.Now;
                await _productDal.UpdateAsync(product);
                return new DataResult<ProductDto>(ResultStatus.Success, Messages.Product.Update(oldProduct.Name), entity);
            }
            return new DataResult<ProductDto>(ResultStatus.Error, Messages.Product.Update(oldProduct.Name), entity);
        }
    }
}
