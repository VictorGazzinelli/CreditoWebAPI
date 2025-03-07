using CreditoWebAPI.Application.Exceptions;
using CreditoWebAPI.Responses;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CreditoWebAPI.Handlers
{
    public static class CustomExceptionHandler
    {
        private static readonly IDictionary<Type, Func<Exception, ErrorResponse>> _exceptionHandlers = new Dictionary<Type, Func<Exception, ErrorResponse>>()
        {
            [typeof(ValidationException)] = HandleValidationException,
            [typeof(AgenteInativoException)] = HandleAgenteInativoException,
            [typeof(AgenteNaoEncontradoException)] = HandleAgenteNaoEncontradoException,
            [typeof(LojaNaoEncontradaException)] = HandleLojaNaoEncontradaException,
            [typeof(LojaNaoHomologadaException)] = HandleLojaNaoHomologadaException,
            [typeof(ProponenteNaoEncontradoException)] = HandleProponenteNaoEncontradoException,
            [typeof(ValorParcelaExcedeLimiteException)] = HandleValorParcelaExcedeLimiteException,
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

        private static ErrorResponse HandleValidationException(Exception exception)
            => new ErrorResponse(exception as ValidationException);

        private static ErrorResponse HandleAgenteInativoException(Exception exception)
            => new ErrorResponse(exception as AgenteInativoException);

        private static ErrorResponse HandleAgenteNaoEncontradoException(Exception exception)
            => new ErrorResponse(exception as AgenteNaoEncontradoException);

        private static ErrorResponse HandleLojaNaoEncontradaException(Exception exception)
            => new ErrorResponse(exception as LojaNaoEncontradaException);

        private static ErrorResponse HandleLojaNaoHomologadaException(Exception exception)
            => new ErrorResponse(exception as LojaNaoHomologadaException);

        private static ErrorResponse HandleProponenteNaoEncontradoException(Exception exception)
            => new ErrorResponse(exception as ProponenteNaoEncontradoException);

        private static ErrorResponse HandleValorParcelaExcedeLimiteException(Exception exception)
            => new ErrorResponse(exception as ValorParcelaExcedeLimiteException);
    }
}
