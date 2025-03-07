using CreditoWebAPI.Filters;
using CreditoWebAPI.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CreditoWebAPI.Options
{
    public class CustomMvcOptions
    {
        public static void AddCustomResponseFilters(MvcOptions options)
        {
            options.Filters.Add<ExceptionFilter>();
            options.Filters.Add(new ProducesResponseTypeAttribute(typeof(BadRequestResponse), StatusCodes.Status400BadRequest));
            options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status401Unauthorized));
            options.Filters.Add(new ProducesResponseTypeAttribute(typeof(ErrorResponse), StatusCodes.Status500InternalServerError));
        }
    }
}
