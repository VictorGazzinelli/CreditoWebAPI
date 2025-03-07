namespace CreditoWebAPI.Application.Interfaces.Services
{
    public interface ITaxaJurosServico
    {
        Task<double> ObterTaxaJurosAoAnoAsync(string cpfProponente);
    }
}
