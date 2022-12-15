using AutoMapper;

namespace TaskSehirTeknolojileri_Service.Mappings.AutoMapper
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProjectMappings>();
            });
            return config.CreateMapper();
        });
        public static IMapper Mapper => lazy.Value;

    }
}
