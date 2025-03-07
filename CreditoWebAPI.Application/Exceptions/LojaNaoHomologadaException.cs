namespace CreditoWebAPI.Application.Exceptions
{
    [Serializable]
    public class LojaNaoHomologadaException : Exception
    {
        public LojaNaoHomologadaException()
        {
        }

        public LojaNaoHomologadaException(string? message) : base(message)
        {
        }

        public LojaNaoHomologadaException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}