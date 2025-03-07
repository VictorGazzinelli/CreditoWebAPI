using System.Runtime.Serialization;

namespace CreditoWebAPI.Application.Exceptions
{
    [Serializable]
    public class LojaNaoEncontradaException : Exception
    {
        public LojaNaoEncontradaException()
        {
        }

        public LojaNaoEncontradaException(string? message) : base(message)
        {
        }

        public LojaNaoEncontradaException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected LojaNaoEncontradaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
