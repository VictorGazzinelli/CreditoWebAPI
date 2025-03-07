using CreditoWebAPI.Application.Interfaces.Repositories;
using CreditoWebAPI.Application.Interfaces.Services;
using CreditoWebAPI.Infrastructure.Database.Repositories;
using CreditoWebAPI.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CreditoWebAPI.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            AddRepositoryDependencies(services);
            AddServiceDependencies(services);

            return services;
        }

        private static void AddRepositoryDependencies(IServiceCollection services)
        {
            services.AddScoped<IProponenteRepositorio, ProponenteRepositorio>();
            services.AddScoped<IAgenteRepositorio, AgenteRepositorio>();
            services.AddScoped<ILojaRepositorio, LojaRepositorio>();
            services.AddScoped<IPropostaRepositorio, PropostaRepositorio>();
        }

        private static void AddServiceDependencies(IServiceCollection services)
        {
            services.AddScoped<ITaxaJurosServico, TaxaJurosServico>();
        }
    }
}
