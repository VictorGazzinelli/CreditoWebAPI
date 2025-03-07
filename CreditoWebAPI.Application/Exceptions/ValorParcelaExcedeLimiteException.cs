namespace CreditoWebAPI.Application.Exceptions
{
    [Serializable]
    public class ValorParcelaExcedeLimiteException : Exception
    {
        public ValorParcelaExcedeLimiteException()
        {
        }

        public ValorParcelaExcedeLimiteException(string? message) : base(message)
        {
        }

        public ValorParcelaExcedeLimiteException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}