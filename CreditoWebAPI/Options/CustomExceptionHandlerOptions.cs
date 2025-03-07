using CreditoWebAPI.Handlers;
using CreditoWebAPI.Responses;
using Microsoft.AspNetCore.Diagnostics;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace CreditoWebAPI.Options
{
    public class CustomExceptionHandlerOptions : ExceptionHandlerOptions
    {
        public CustomExceptionHandlerOptions()
        {
            this.ExceptionHandlingPath = "/error";
            this.ExceptionHandler = OnGlobalExceptionAsync;
            this.StatusCodeSelector = CustomExceptionHandler.HandleException;
        }

        public static async Task OnGlobalExceptionAsync(HttpContext context)
        {
            IExceptionHandlerFeature exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
            Exception exception = exceptionHandlerFeature?.Error;
            context.Response.ContentType = $"{MediaTypeNames.Application.Json};charset=UTF-8";
            ErrorResponse errorResponse = CustomExceptionHandler.HandleExceptionAsErrorResponse(exception);
            context.Response.StatusCode = errorResponse.StatusCode;
            object responseBody = new { message = errorResponse.Message };
            string serializedResponseBody = JsonSerializer.Serialize(responseBody);
            byte[] encodedResponseBody = Encoding.UTF8.GetBytes(serializedResponseBody);
            await context.Response.Body.WriteAsync(encodedResponseBody, 0, encodedResponseBody.Length);
        }
    }
}
