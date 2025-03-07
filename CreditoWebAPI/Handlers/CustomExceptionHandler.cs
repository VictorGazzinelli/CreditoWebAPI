using CreditoWebAPI.Responses;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CreditoWebAPI.Handlers
{
    public static class CustomExceptionHandler
    {
        private static readonly IDictionary<Type, Func<Exception, ErrorResponse>> _exceptionHandlers = new Dictionary<Type, Func<Exception, ErrorResponse>>()
        {
            [typeof(Exception)] = HandleGenericException,
        };

        public static int HandleException(Exception exception)
        {
            Type exceptionType = exception.GetType();
            ErrorResponse errorResponse = HandleExceptionAsErrorResponse(exception);

            return errorResponse.StatusCode;
        }

        public static void HandleExceptionContext(ExceptionContext context)
        {
            context.Result = HandleExceptionAsErrorResponse(context.Exception)
                .AsObjectResult();
            context.ExceptionHandled = true;
        }

        public static ErrorResponse HandleExceptionAsErrorResponse(Exception exception)
        {
            if (exception is null)
                throw new ArgumentNullException(nameof(exception));

            Type exceptionType = exception.GetType();

            if (HasRegistredHandlerFor(exceptionType))
                return HandleException(exception, exceptionType);

            return new ErrorResponse(exception);
        }

        private static bool HasRegistredHandlerFor(Type exceptionType)
            => _exceptionHandlers.ContainsKey(exceptionType);

        private static ErrorResponse HandleException(Exception exception, Type exceptionType)
            => _exceptionHandlers[exceptionType](exception);

        private static ErrorResponse HandleGenericException(Exception exception)
            => new ErrorResponse(exception as Exception);
    }
}
