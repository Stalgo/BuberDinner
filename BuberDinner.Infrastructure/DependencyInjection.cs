using BuberDinner.Application.Common.Inferfaces.Persistence;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Services;
using BuberDinner.Infrastructure.Authentication;
using BuberDinner.Infrastructure.Persistence;
using BuberDinner.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastucture(
            this IServiceCollection services,
            ConfigurationManager configurationManager
        )
        {
            _ = services.Configure<JwtSettings>(configurationManager.GetSection(JwtSettings.SectionName));
            _ = services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            _ = services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            _ = services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
