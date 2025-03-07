using CreditoWebAPI.Application.Responses.Propostas;
using MediatR;

namespace CreditoWebAPI.Application.Requests.Propostas
{
    public class ValidarPropostaRequisicao : IRequest<ValidarPropostaResposta>
    {
        public Guid Id { get; set; }
    }
}
