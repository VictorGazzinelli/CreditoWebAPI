using CreditoWebAPI.Domain.Enums;

namespace CreditoWebAPI.Application.Dtos
{
    public class PropostaDto
    {
        public Guid Id { get; set; }
        public string CpfProponente { get; set; }
        public double ValorSolicitado { get; set; }
        public int QuantidadeParcelas { get; set; }
        public double ValorParcela { get; set; }
        public DateTimeOffset Data { get; set; }
        public StatusPorpostaEnum Status { get; set; }
    }
}
