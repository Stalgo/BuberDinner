using System.Text;
using BuberDinner.Application.Common.Inferfaces.Persistence;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Services;
using BuberDinner.Infrastructure.Authentication;
using BuberDinner.Infrastructure.Persistence;
using BuberDinner.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BuberDinner.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastucture(
            this IServiceCollection services,
            ConfigurationManager configurationManager
        )
        {
            _ = services.AddAuth(configurationManager);
            _ = services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            _ = services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }

        public static IServiceCollection AddAuth(
            this IServiceCollection services,
            ConfigurationManager configurationManager
        )
        {
            JwtSettings jwtSettings = new();
            configurationManager.Bind(JwtSettings.SectionName, jwtSettings);

            _ = services.AddSingleton(Options.Create(jwtSettings));
            _ = services.Configure<JwtSettings>(configurationManager.GetSection(JwtSettings.SectionName));
            _ = services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            _ = services
                .AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                    }
                );

            return services;
        }
    }
}
