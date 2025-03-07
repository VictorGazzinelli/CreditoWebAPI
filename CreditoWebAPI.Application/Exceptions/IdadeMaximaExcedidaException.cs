using System.Runtime.Serialization;

namespace CreditoWebAPI.Application.Exceptions
{
    [Serializable]
    public class IdadeMaximaExcedidaException : Exception
    {
        public IdadeMaximaExcedidaException()
        {
        }

        public IdadeMaximaExcedidaException(string? message) : base(message)
        {
        }

        public IdadeMaximaExcedidaException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected IdadeMaximaExcedidaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
