using CreditoWebAPI.Application.Responses.Propostas;
using MediatR;

namespace CreditoWebAPI.Application.Requests.Propostas
{
    public class ObterPropostaRequisicao : IRequest<ObterPropostaResposta>
    {
        public Guid Id { get; set; }
    }
}
