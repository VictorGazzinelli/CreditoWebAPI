using MediatR;

namespace CreditoWebAPI.Application.Requests.Propostas
{
    public class ProcessarPropostaRequisicao : IRequest
    {
        public Guid Id { get; set; }
    }
}
