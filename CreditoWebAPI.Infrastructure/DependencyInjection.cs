﻿using Microsoft.Extensions.DependencyInjection;

namespace CreditoWebAPI.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            return services;
        }
    }
}
