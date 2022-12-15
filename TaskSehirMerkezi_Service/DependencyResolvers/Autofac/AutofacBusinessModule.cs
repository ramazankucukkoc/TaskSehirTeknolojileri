using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using NLayer_Backend_Core.Utilities.Security.Jwt;
using TaskSehirTeknolojileri_Core.Utilities.Interceptors;
using TaskSehirTeknolojileri_Data.DataAccess.Abstract;
using TaskSehirTeknolojileri_Data.DataAccess.Concrete;
using TaskSehirTeknolojileri_Service.Abstract;
using TaskSehirTeknolojileri_Service.Concrete;

namespace TaskSehirTeknolojileri_Service.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<CustomerManager>().As<ICustomerService>();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>();

          


            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<UserManager>().As<IUserService>();

            builder.RegisterType<EfUserDal>().As<IUserDal>();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
              .EnableInterfaceInterceptors(new ProxyGenerationOptions()
              {
                  Selector = new AspectInterceptorSelector()
              }).SingleInstance();


        }
    }
}
