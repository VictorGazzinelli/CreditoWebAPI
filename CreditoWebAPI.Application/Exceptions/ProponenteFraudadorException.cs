using System.Runtime.Serialization;

namespace CreditoWebAPI.Application.Exceptions
{
    [Serializable]
    public class ProponenteFraudadorException : Exception
    {
        public ProponenteFraudadorException()
        {
        }

        public ProponenteFraudadorException(string? message) : base(message)
        {
        }

        public ProponenteFraudadorException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ProponenteFraudadorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
