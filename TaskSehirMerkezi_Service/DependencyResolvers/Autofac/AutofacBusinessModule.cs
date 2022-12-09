using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using TaskSehirTeknolojileri_Service.Abstract;
using TaskSehirTeknolojileri_Service.Concrete;
using AuthenticationManager = TaskSehirTeknolojileri_Service.Concrete.AuthenticationManager;
using Autofac;
using TaskSehirTeknolojileri_Data.DataAccess.Abstract;
using TaskSehirTeknolojileri_Data.DataAccess.Concrete;
using TaskSehirTeknolojileri_Data.UnitOfWork;

namespace TaskSehirTeknolojileri_Service.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<CustomerManager>().As<ICustomerService>();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>();

            builder.RegisterType<UserRefreshTokenManager>().As<IRefreshTokenService>();
            builder.RegisterType<EfRefreshTokenDal>().As<IUserRefreshTokenDal>();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            builder.RegisterType<AuthenticationManager>().As<IAuthenticetionService>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<TokenManager>().As<ITokenService>();


        }
    }
}
