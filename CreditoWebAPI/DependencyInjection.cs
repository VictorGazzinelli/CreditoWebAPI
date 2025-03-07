using CreditoWebAPI.Application;
using CreditoWebAPI.Handlers;
using CreditoWebAPI.Infrastructure;
using CreditoWebAPI.Options;
using CreditoWebAPI.Utils;
using CreditoWebAPI.Validators.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;

namespace CreditoWebAPI
{
    public static class DependencyInjection
    {
        public static void ConfigureApiServices(this IServiceCollection services)
        {
            services.AddCors(CustomCorsOptions.UseDefaultPolicy);
            services.AddAuthentication(ApiConstants.AuthScheme)
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>(ApiConstants.AuthScheme, CustomAuthenticationOptions.SetupApiAuthentication);
            services.AddAuthorization(CustomAuthorizationOptions.UseBasicAuthorization);
            services.AddDataProtection()
                .PersistKeysToFileSystem(new DirectoryInfo(@"\keys\"));
            services.AddSwaggerGen(CustomSwaggerOptions.SetupSwaggerDoc);
            services.AddEndpointsApiExplorer();
            services.AddHttpContextAccessor();
            services.AddHttpClient();
            services.Configure<ApiBehaviorOptions>(CustomApiBehaviourOptions.SuppressDefaultFilters);
            services.AddControllers(CustomMvcOptions.AddCustomResponseFilters);

            services.AddValidatorsFromAssemblyContaining(typeof(ValidatorExtensions));
            services.AddApplicationDependencies();
            services.AddInfrastructureDependencies();
        }

        public static void ConfigureHttpRequestPipeline(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(CustomSwaggerUiOptions.SetupSwaggerUi);
            }

            app.UseExceptionHandler(new CustomExceptionHandlerOptions());
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
        }
    }
}
