using Microsoft.AspNetCore.Mvc;

namespace CreditoWebAPI.Responses
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ErrorResponse()
        {
            
        }

        public ErrorResponse(Exception exception)
        {
            StatusCode = 500;
            Message = exception.Message;
        }

        public ObjectResult AsObjectResult()
            => new ObjectResult(this)
            {
                StatusCode = this.StatusCode
            };
    }
}
