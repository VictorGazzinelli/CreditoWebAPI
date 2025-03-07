using CreditoWebAPI.Application.Interfaces.Repositories;
using CreditoWebAPI.Application.Interfaces.Services;
using CreditoWebAPI.Application.Requests.Propostas;
using CreditoWebAPI.Domain.Entities;
using CreditoWebAPI.Domain.Enums;
using MediatR;

namespace CreditoWebAPI.Application.Handlers.Propostas
{
    public class ProcessarPropostaHandler : IRequestHandler<ProcessarPropostaRequisicao>
    {
        private readonly IPropostaRepositorio _propostaRepositorio;
        private readonly ISpcServico _spcServico;
        private readonly ISerasaServico _serasaServico;

        public ProcessarPropostaHandler(IPropostaRepositorio propostaRepositorio, ISpcServico spcServico, ISerasaServico serasaServico)
        {
            _propostaRepositorio = propostaRepositorio;
            _spcServico = spcServico;
            _serasaServico = serasaServico;
        }

        public async Task Handle(ProcessarPropostaRequisicao request, CancellationToken cancellationToken)
        {
            Proposta proposta = await _propostaRepositorio.ObterAsync(request.Id, cancellationToken);

            int scoreSpc =  _spcServico.ObterScore(proposta.CpfProponente);

            if(scoreSpc < 7)
            {
                await ReporvarAsync(proposta, cancellationToken);
                return;
            }

            int scoreSerasa = _serasaServico.ObterScore(proposta.CpfProponente);

            if (scoreSerasa < 7)
            {
                await ReporvarAsync(proposta, cancellationToken);
                return;
            }

            await AprovarAsync(proposta, cancellationToken);
        }

        private async Task AprovarAsync(Proposta proposta, CancellationToken cancellationToken)
        {
            proposta.Status = StatusPropostaEnum.Aprovada;

            await _propostaRepositorio.EditarAsync(proposta, cancellationToken);
        }

        private async Task ReporvarAsync(Proposta proposta, CancellationToken cancellationToken)
        {
            proposta.Status = StatusPropostaEnum.Reprovada;

            await _propostaRepositorio.EditarAsync(proposta, cancellationToken);
        }
    }
}
