using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CreditoWebAPI.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            Assembly[] assemblies = new[] { Assembly.GetExecutingAssembly() };
            services.AddMediatR(config =>
            {
                config.Lifetime = ServiceLifetime.Scoped;
                config.RegisterServicesFromAssemblies(assemblies);
            });
            services.AddAutoMapper(assemblies);

            return services;
        }
    }
}
