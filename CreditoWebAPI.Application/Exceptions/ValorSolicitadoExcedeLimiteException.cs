namespace CreditoWebAPI.Application.Exceptions
{
    [Serializable]
    public class ValorSolicitadoExcedeLimiteException : Exception
    {
        public ValorSolicitadoExcedeLimiteException()
        {
        }

        public ValorSolicitadoExcedeLimiteException(string? message) : base(message)
        {
        }

        public ValorSolicitadoExcedeLimiteException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}