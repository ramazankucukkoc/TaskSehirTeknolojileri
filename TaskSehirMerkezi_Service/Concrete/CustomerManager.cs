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

    public class CustomerManager : ICustomerService
    {

        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public async Task<IDataResult<CustomerDto>> AddAsync(CustomerDto entity)
        {
            var customer = ObjectMapper.Mapper.Map<Customer>(entity);
            if (customer != null)
            {
                customer.CreatedDate = DateTime.Now;
                await _customerDal.AddAsync(customer);
                return new DataResult<CustomerDto>(ResultStatus.Success, Messages.Customer.Add(customer.FirstName + " " + customer.LastName), entity);
            }
            return new DataResult<CustomerDto>(ResultStatus.Error, Messages.Customer.NotAdd(customer.FirstName + " " + customer.LastName), null);
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var customerCount = await _customerDal.CountAsync();
            if (customerCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, Messages.Customer.Count(customerCount), customerCount);
            }
            return new DataResult<int>(ResultStatus.Error, Messages.Customer.Count(customerCount), -1);
        }

        public async Task<IDataResult<CustomerDto>> DeleteAsync(CustomerDto entity)
        {
            var customer = await _customerDal.GetAsync(p => p.Id == entity.Id);
            if (customer != null)
            {
                customer.IsDeleted = true;
                customer.ModifiedDate = DateTime.Now;
                await _customerDal.UpdateAsync(customer);
                return new DataResult<CustomerDto>(ResultStatus.Success, Messages.Customer.Delete(customer.FirstName + " " + customer.LastName), entity);
            }
            return new DataResult<CustomerDto>(ResultStatus.Error, Messages.Customer.NonDelete(customer.FirstName + " " + customer.LastName), null);
        }
        [SecuredOperation("Editor")]
        //[CacheAspect(duration: 20)]
        public async Task<IDataResult<List<CustomerDto>>> GetAllNonDeletedAsync()
        {
            var getallCustomer = await _customerDal.GetAllAsync(p => !p.IsDeleted);
            if (getallCustomer.Count > -1)
            {
                var getAllNonDeleted = ObjectMapper.Mapper.Map<List<CustomerDto>>(getallCustomer);
                return new DataResult<List<CustomerDto>>(ResultStatus.Success, getAllNonDeleted);
            }
            return new DataResult<List<CustomerDto>>(ResultStatus.Error, Messages.Customer.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<CustomerDto>> UpdateAsync(CustomerDto entity)
        {
            var oldCustomer = await _customerDal.GetAsync(p => p.Id == entity.Id);
            if (entity != null)
            {
                var customer = ObjectMapper.Mapper.Map<CustomerDto, Customer>(entity, oldCustomer);
                customer.ModifiedDate = DateTime.Now;
                await _customerDal.UpdateAsync(customer);
                return new DataResult<CustomerDto>(ResultStatus.Success, Messages.Customer.Update(oldCustomer.FirstName + " " + oldCustomer.LastName), entity);
            }
            return new DataResult<CustomerDto>(ResultStatus.Error, Messages.Customer.Update(oldCustomer.FirstName + " " + oldCustomer.LastName), entity);
        }
    }
}
