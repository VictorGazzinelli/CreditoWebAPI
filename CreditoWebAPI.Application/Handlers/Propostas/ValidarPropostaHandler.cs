using CreditoWebAPI.Application.Exceptions;
using CreditoWebAPI.Application.Interfaces.Repositories;
using CreditoWebAPI.Application.Requests.Propostas;
using CreditoWebAPI.Application.Responses.Propostas;
using CreditoWebAPI.Domain.Entities;
using MediatR;

namespace CreditoWebAPI.Application.Handlers.Propostas
{
    public class ValidarPropostaHandler : IRequestHandler<ValidarPropostaRequisicao, ValidarPropostaResposta>
    {
        private readonly IPropostaRepositorio _propostaRepositorio;

        public ValidarPropostaHandler(IPropostaRepositorio propostaRepositorio)
        {
            _propostaRepositorio = propostaRepositorio;
        }

        public async Task<ValidarPropostaResposta> Handle(ValidarPropostaRequisicao request, CancellationToken cancellationToken)
        {
            Proposta proposta = await _propostaRepositorio.ObterAsync(request.Id, cancellationToken);

            if (proposta == null)
                throw new PropostaNaoEncontradaException("Proposta nao foi encontrada");

            if (proposta.Status.FoiFinalizada)
                throw new PropostaJaFinalizadaException("Proposta ja foi finalizada");

            if (!proposta.Agente.Ativo)
                throw new AgenteInativoException("Agente esta inativo");

            if (UfPossuiRestricaoDeValor(proposta.Loja.Uf, proposta.ValorSolicitado))
                throw new ValorSolicitadoExcedeLimiteException("Valor da parcela excede o limite permitido para a UF da loja");

            return new ValidarPropostaResposta()
            {
                Valido = true
            };
        }

        private bool UfPossuiRestricaoDeValor(string uf, double valorSolicitado)
            => uf == "RS" && valorSolicitado > 10000;
    }
}
