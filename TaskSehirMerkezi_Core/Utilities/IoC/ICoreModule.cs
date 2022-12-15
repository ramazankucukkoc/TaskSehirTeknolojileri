using Microsoft.Extensions.DependencyInjection;

namespace TaskSehirTeknolojileri_Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection services);
    }
}
