using Microsoft.Extensions.DependencyInjection;
using TaskSehirTeknolojileri_Core.Utilities.IoC;

namespace TaskSehirTeknolojileri_Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection services, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(services);
            }
            return ServiceTool.Create(services);
        }
    }
}
