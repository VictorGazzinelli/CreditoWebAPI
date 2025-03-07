using AutoMapper;
using CreditoWebAPI.Application.Dtos;
using CreditoWebAPI.Application.Interfaces.Repositories;
using CreditoWebAPI.Application.Requests.Propostas;
using CreditoWebAPI.Application.Responses.Propostas;
using MediatR;

namespace CreditoWebAPI.Application.Handlers.Propostas
{
    public class ListarPropostaHandler : IRequestHandler<ListarPropostaRequisicao, ListarPropostaResposta>
    {
        private readonly IPropostaRepositorio _propostaRepositorio;
        private readonly IMapper _mapper;

        public ListarPropostaHandler(IPropostaRepositorio propostaRepositorio, IMapper mapper)
        {
            _propostaRepositorio = propostaRepositorio;
            _mapper = mapper;
        }

        public async Task<ListarPropostaResposta> Handle(ListarPropostaRequisicao request, CancellationToken cancellationToken)
        {
            var propostas = await _propostaRepositorio.ListarAsync(proposta => true, cancellationToken);

            ListarPropostaResposta resposta = new ListarPropostaResposta()
            {
                Propostas = _mapper.ProjectTo<PropostaDto>(propostas)
            };

            return resposta;
        }
    }
}
