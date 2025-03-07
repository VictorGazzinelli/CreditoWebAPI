using CreditoWebAPI.Utils;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CreditoWebAPI.Options
{
    public static class CustomSwaggerOptions
    {
        public static void SetupSwaggerDoc(SwaggerGenOptions options)
        {
            string xmlFileName = $"{ApiConstants.Name}.xml";
            string xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
            OpenApiInfo openApiInfo = new OpenApiInfo()
            {
                Title = ApiConstants.Name,
                Version = ApiConstants.Version
            };
            OpenApiReference basicAuthOpenApiReference = new OpenApiReference()
            {
                Id = ApiConstants.AuthScheme,
                Type = ReferenceType.SecurityScheme,
            };
            OpenApiSecurityScheme basicAuthOpenApiSecurityScheme = new OpenApiSecurityScheme()
            {
                Description = $"Authorization header using the {ApiConstants.AuthScheme} scheme.",
                Type = SecuritySchemeType.Http,
                Scheme = ApiConstants.AuthScheme,
                Reference = basicAuthOpenApiReference,

            };
            OpenApiSecurityRequirement basicAuthOpenApiSecurityRequirement = new OpenApiSecurityRequirement()
            {
                { basicAuthOpenApiSecurityScheme, new List<string>() }
            };

            options.CustomSchemaIds(type => type.ToString());
            options.SwaggerDoc(ApiConstants.Version, openApiInfo);
            options.OrderActionsBy((apiDesc) => $"{apiDesc.ActionDescriptor.RouteValues["controller"]}_{apiDesc.HttpMethod}_{apiDesc.RelativePath}");
            //options.IncludeXmlComments(xmlFilePath);
            options.AddSecurityDefinition(ApiConstants.AuthScheme, basicAuthOpenApiSecurityScheme);
            options.AddSecurityRequirement(basicAuthOpenApiSecurityRequirement);
        }
    }
}
