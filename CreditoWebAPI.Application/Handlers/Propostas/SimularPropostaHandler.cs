using CreditoWebAPI.Application.Exceptions;
using CreditoWebAPI.Application.Interfaces.Repositories;
using CreditoWebAPI.Application.Interfaces.Services;
using CreditoWebAPI.Application.Requests.Propostas;
using CreditoWebAPI.Application.Responses.Propostas;
using CreditoWebAPI.Domain.Entities;
using MediatR;

namespace CreditoWebAPI.Application.Handlers.Propostas
{
    public class SimularPropostaHandler : IRequestHandler<SimularPropostaRequisicao, SimularPropostaResposta>
    {
        private readonly IProponenteRepositorio _proponenteRepositorio;
        private readonly ITaxaJurosServico taxaJurosServico;

        public SimularPropostaHandler(IProponenteRepositorio proponenteRepositorio)
        {
            _proponenteRepositorio = proponenteRepositorio;
        }

        public async Task<SimularPropostaResposta> Handle(SimularPropostaRequisicao request, CancellationToken cancellationToken)
        {
            Proponente proponente = await _proponenteRepositorio.ObterAsync(request.CpfProponente, cancellationToken);

            if (proponente == null)
                throw new ProponenteNaoEncontradoException($"Proponenete com cpf {request.CpfProponente} nao encontrado");

            double numeroAnos = request.QuantidadeParcelas / 12;
            double taxaAoAno = await taxaJurosServico.ObterTaxaJurosAoAnoAsync(request.CpfProponente);
            double valorTotal = request.ValorSolicitado * Math.Pow(1 + taxaAoAno, numeroAnos);
            double valorParcela = valorTotal / request.QuantidadeParcelas;
            double valorMaximoParcela = proponente.ValorAposentadoria * 0.3;

            if(valorParcela > valorMaximoParcela)
                throw new ValorSolicitadoExcedeLimiteException($"Valor da parcela excede o limite de 30% da aposentadoria do proponente");

            SimularPropostaResposta resposta = new SimularPropostaResposta()
            {
                ValorParcela = valorParcela,
            };

            return resposta;
        }
    }
}
