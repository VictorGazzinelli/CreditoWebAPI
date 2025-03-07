using CreditoWebAPI.Application.Responses.Propostas;
using MediatR;

namespace CreditoWebAPI.Application.Requests.Propostas
{
    public class SimularPropostaRequisicao : IRequest<SimularPropostaResposta>
    {
        public string CpfProponente { get; set; }
        public double ValorSolicitado { get; set; }
        public int QuantidadeParcelas { get; set; }
    }
}
