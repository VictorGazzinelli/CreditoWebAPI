using CreditoWebAPI.Application.Responses.Propostas;
using MediatR;

namespace CreditoWebAPI.Application.Requests.Propostas
{
    public class IncluirPropostaRequisicao : IRequest<IncluirPropostaResposta>
    {
        public string CpfProponente { get; set; }
        public Guid IdAgente { get; set; }
        public Guid IdLoja { get; set; }

        public double ValorSolicitado { get; set; }
        public int QuantidadeParcelas { get; set; }
        public double ValorParcela { get; set; }
        public DateTimeOffset Data { get; set; }
    }
}
