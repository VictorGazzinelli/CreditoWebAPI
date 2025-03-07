namespace CreditoWebAPI.Application.Exceptions
{
    [Serializable]
    public class AgenteInativoException : Exception
    {
        public AgenteInativoException()
        {
        }

        public AgenteInativoException(string? message) : base(message)
        {
        }

        public AgenteInativoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}