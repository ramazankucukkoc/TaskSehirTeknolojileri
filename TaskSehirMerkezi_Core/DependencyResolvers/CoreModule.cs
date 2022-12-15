using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using TaskSehirTeknolojileri_Core.CrossCuttingConcerns.Caching;
using TaskSehirTeknolojileri_Core.CrossCuttingConcerns.Caching.Microsoft;
using TaskSehirTeknolojileri_Core.Utilities.IoC;

namespace TaskSehirTeknolojileri_Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<ICacheService, MemoryCacheManager>();
        }
    }
}
