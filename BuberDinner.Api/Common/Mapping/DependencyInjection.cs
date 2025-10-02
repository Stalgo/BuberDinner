using System.Reflection;
using Mapster;
using MapsterMapper;

namespace BuberDinner.Api.Common.Mapping
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            TypeAdapterConfig config = TypeAdapterConfig.GlobalSettings;
            _ = config.Scan(Assembly.GetExecutingAssembly());
            _ = services.AddSingleton(config);
            _ = services.AddScoped<IMapper, ServiceMapper>();
            return services;
        }
    }
}
