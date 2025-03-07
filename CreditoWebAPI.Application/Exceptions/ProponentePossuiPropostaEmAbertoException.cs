using System.Runtime.Serialization;

namespace CreditoWebAPI.Application.Exceptions
{
    [Serializable]
    public class ProponentePossuiPropostaEmAbertoException : Exception
    {
        public ProponentePossuiPropostaEmAbertoException()
        {
        }

        public ProponentePossuiPropostaEmAbertoException(string? message) : base(message)
        {
        }

        public ProponentePossuiPropostaEmAbertoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ProponentePossuiPropostaEmAbertoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
