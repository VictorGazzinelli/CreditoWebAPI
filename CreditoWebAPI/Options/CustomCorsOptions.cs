using Microsoft.AspNetCore.Cors.Infrastructure;

namespace CreditoWebAPI.Options
{
    public static class CustomCorsOptions
    {
        private static readonly CorsPolicy _defaultPolicy = new CorsPolicyBuilder()
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
            .Build();

        public static void UseDefaultPolicy(this CorsOptions options)
            => options.AddDefaultPolicy(_defaultPolicy);
    }
}
