using System.Runtime.Serialization;

namespace CreditoWebAPI.Application.Exceptions
{
    [Serializable]
    public class PropostaNaoEncontradaException : Exception
    {
        public PropostaNaoEncontradaException()
        {
        }

        public PropostaNaoEncontradaException(string? message) : base(message)
        {
        }

        public PropostaNaoEncontradaException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PropostaNaoEncontradaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
