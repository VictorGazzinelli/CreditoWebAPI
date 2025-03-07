using CreditoWebAPI.Utils;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace CreditoWebAPI.Options
{
    public static class CustomSwaggerUiOptions
    {
        public static void SetupSwaggerUi(SwaggerUIOptions options)
        {
            options.SwaggerEndpoint($"/swagger/{ApiConstants.Version}/swagger.json", $"{ApiConstants.Name} {ApiConstants.Version}");
            options.RoutePrefix = string.Empty;
            options.DisplayRequestDuration();
            options.EnableFilter();
            options.EnableDeepLinking();
        }
    }
}
