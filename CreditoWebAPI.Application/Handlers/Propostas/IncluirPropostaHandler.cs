using CreditoWebAPI.Application.Dtos;
using CreditoWebAPI.Application.Requests.Propostas;
using CreditoWebAPI.Application.Responses.Propostas;
using MediatR;

namespace CreditoWebAPI.Application.Handlers.Propostas
{
    public class IncluirPropostaHandler : IRequestHandler<IncluirPropostaRequisicao, IncluirPropostaResposta>
    {
        public Task<IncluirPropostaResposta> Handle(IncluirPropostaRequisicao request, CancellationToken cancellationToken)
        {
            IncluirPropostaResposta resposta = new IncluirPropostaResposta()
            {
                Proposta = new PropostaValidaDto()
                    {
                        EhValida = true,
                    }
            };

            return Task.FromResult(resposta);
        }
    }
}
