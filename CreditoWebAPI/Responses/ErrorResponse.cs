using CreditoWebAPI.Application.Exceptions;
using CreditoWebAPI.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CreditoWebAPI.Responses
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public Dictionary<string, string> Errors { get; set; } = new Dictionary<string, string>();

        public ErrorResponse()
        {
            
        }

        public ErrorResponse(Exception exception)
        {
            StatusCode = 500;
            Message = exception.Message;
        }

        public ErrorResponse(ValidationException validationException)
        {
            StatusCode = 400;
            Message = "One or more errors occured.";
            Errors = validationException.Errors.ToDictionary(e => e.PropertyName.ToCamelCase(), e => e.ErrorMessage);
        }

        public ErrorResponse(AgenteInativoException agenteInativoException)
        {
            StatusCode = 400;
            Message = agenteInativoException.Message;
        }

        public ErrorResponse(AgenteNaoEncontradoException agenteNaoEncontradoException)
        {
            StatusCode = 404;
            Message = agenteNaoEncontradoException.Message;
        }

        public ErrorResponse(LojaNaoEncontradaException lojaNaoEncontradaException)
        {
            StatusCode = 404;
            Message = lojaNaoEncontradaException.Message;
        }

        public ErrorResponse(LojaNaoHomologadaException lojaNaoHomologadaException)
        {
            StatusCode = 400;
            Message = lojaNaoHomologadaException.Message;
        }

        public ErrorResponse(ProponenteNaoEncontradoException proponenteNaoEncontradoException)
        {
            StatusCode = 404;
            Message = proponenteNaoEncontradoException.Message;
        }

        public ErrorResponse(ValorParcelaExcedeLimiteException valorParcelaExcedeLimiteException)
        {
            StatusCode = 400;
            Message = valorParcelaExcedeLimiteException.Message;
        }

        public ObjectResult AsObjectResult()
            => new ObjectResult(this)
            {
                StatusCode = this.StatusCode
            };
    }
}
