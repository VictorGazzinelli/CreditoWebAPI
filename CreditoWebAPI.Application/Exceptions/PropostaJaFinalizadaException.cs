using System.Runtime.Serialization;

namespace CreditoWebAPI.Application.Exceptions
{
    [Serializable]
    public class PropostaJaFinalizadaException : Exception
    {
        public PropostaJaFinalizadaException()
        {
        }

        public PropostaJaFinalizadaException(string? message) : base(message)
        {
        }

        public PropostaJaFinalizadaException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PropostaJaFinalizadaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
