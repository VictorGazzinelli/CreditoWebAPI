using System.Runtime.Serialization;

namespace CreditoWebAPI.Application.Exceptions
{
    [Serializable]
    public class ProponenteNaoEncontradoException : Exception
    {
        public ProponenteNaoEncontradoException()
        {
        }

        public ProponenteNaoEncontradoException(string? message) : base(message)
        {
        }

        public ProponenteNaoEncontradoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ProponenteNaoEncontradoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
