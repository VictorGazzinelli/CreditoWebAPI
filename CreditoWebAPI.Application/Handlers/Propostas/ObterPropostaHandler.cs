using AutoMapper;
using CreditoWebAPI.Application.Dtos;
using CreditoWebAPI.Application.Exceptions;
using CreditoWebAPI.Application.Interfaces.Repositories;
using CreditoWebAPI.Application.Requests.Propostas;
using CreditoWebAPI.Application.Responses.Propostas;
using CreditoWebAPI.Domain.Entities;
using MediatR;

namespace CreditoWebAPI.Application.Handlers.Propostas
{
    public class ObterPropostaHandler : IRequestHandler<ObterPropostaRequisicao, ObterPropostaResposta>
    {
        private readonly IPropostaRepositorio _propostaRepositorio;
        private readonly IMapper _mapper;

        public ObterPropostaHandler(IPropostaRepositorio propostaRepositorio, IMapper mapper)
        {
            _propostaRepositorio = propostaRepositorio;
            _mapper = mapper;
        }

        public async Task<ObterPropostaResposta> Handle(ObterPropostaRequisicao request, CancellationToken cancellationToken)
        {
            Proposta proposta = await _propostaRepositorio.ObterAsync(request.Id, cancellationToken);

            if (proposta == null)
                throw new PropostaNaoEncontradaException("Proposta Nao Encontrada");

            ObterPropostaResposta resposta = new ObterPropostaResposta()
            {
                Proposta = _mapper.Map<PropostaDto>(proposta)
            };

            return resposta;
        }
    }
}
