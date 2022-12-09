using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSehirTeknolojileri_Data.Entities.Concrete;
using TaskSehirTeknolojileri_Data.Entities.Dtos;

namespace TaskSehirTeknolojileri_Service.Mappings.AutoMapper
{
    public class ProjectMappings:Profile
    {
        public ProjectMappings()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductWithCategoryDto>().ReverseMap();
            CreateMap<Category,CategoryDto>().ReverseMap();
            CreateMap<User,UserAppDto>().ReverseMap();
            CreateMap<UserRefreshToken,UserRefreshTokenDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}
