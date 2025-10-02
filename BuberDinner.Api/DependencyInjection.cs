using BuberDinner.Api.Common.Errors;
using BuberDinner.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BuberDinner.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            _ = services.AddControllers();
            _ = services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();
            _ = services.AddMappings();
            return services;
        }
    }
}
