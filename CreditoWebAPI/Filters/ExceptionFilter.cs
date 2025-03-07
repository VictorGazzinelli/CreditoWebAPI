using CreditoWebAPI.Handlers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace CreditoWebAPI.Filters
{
    public class ExceptionFilter : IAsyncExceptionFilter
    {
        private readonly ILogger logger;
        private readonly HttpContext httpContext;

        public ExceptionFilter(ILoggerFactory loggerFactory, IHttpContextAccessor httpContextAccessor)
        {
            this.logger = loggerFactory.CreateLogger<ExceptionFilter>();
            this.httpContext = httpContextAccessor.HttpContext;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            CustomExceptionHandler.HandleExceptionContext(context);
            await LogExceptionContext(context);
        }

        private async Task LogExceptionContext(ExceptionContext exceptionContext)
        {
            string requestBodyStr = await GetRawBodyAsync(httpContext.Request);
            string requestQueryStr = httpContext.Request.QueryString.ToString();
            string errorString = $"ERROR Request: {httpContext.Request.Method} {httpContext.Request.Path}";
            logger.LogError($"{errorString}. \n" +
                $"Message: {exceptionContext.Exception.Message}. \n" +
                $"StackTrace: {exceptionContext.Exception.StackTrace}. \n" +
                $"Body: {requestBodyStr}. \n" +
                $"QueryParams: {requestQueryStr}.");
        }

        private async Task<string> GetRawBodyAsync(HttpRequest request)
        {
            if (!request.Body.CanSeek)
            {
                request.EnableBuffering();
            }

            request.Body.Position = 0;
            StreamReader reader = new StreamReader(request.Body, Encoding.UTF8);
            string body = await reader.ReadToEndAsync().ConfigureAwait(false);
            request.Body.Position = 0;

            return body;
        }
    }
}