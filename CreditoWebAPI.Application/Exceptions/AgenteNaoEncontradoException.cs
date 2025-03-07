using System.Runtime.Serialization;

namespace CreditoWebAPI.Application.Exceptions
{
    [Serializable]
    public class AgenteNaoEncontradoException : Exception
    {
        public AgenteNaoEncontradoException()
        {
        }

        public AgenteNaoEncontradoException(string? message) : base(message)
        {
        }

        public AgenteNaoEncontradoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected AgenteNaoEncontradoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
