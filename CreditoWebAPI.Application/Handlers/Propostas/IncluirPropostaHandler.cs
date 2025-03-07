using AutoMapper;
using CreditoWebAPI.Application.Dtos;
using CreditoWebAPI.Application.Exceptions;
using CreditoWebAPI.Application.Interfaces.Repositories;
using CreditoWebAPI.Application.Requests.Propostas;
using CreditoWebAPI.Application.Responses.Propostas;
using CreditoWebAPI.Domain.Entities;
using CreditoWebAPI.Domain.Enums;
using MediatR;

namespace CreditoWebAPI.Application.Handlers.Propostas
{
    public class IncluirPropostaHandler : IRequestHandler<IncluirPropostaRequisicao, IncluirPropostaResposta>
    {
        private readonly IProponenteRepositorio _proponenteRepositorio;
        private readonly IAgenteRepositorio _agenteRepositorio;
        private readonly ILojaRepositorio _lojaRepositorio;
        private readonly IPropostaRepositorio _propostaRepositorio;
        private readonly IMapper _mapper;

        public IncluirPropostaHandler(IProponenteRepositorio proponenteRepositorio, IAgenteRepositorio agenteRepositorio, ILojaRepositorio lojaRepositorio, IPropostaRepositorio propostaRepositorio, IMapper mapper)
        {
            _proponenteRepositorio = proponenteRepositorio;
            _agenteRepositorio = agenteRepositorio;
            _lojaRepositorio = lojaRepositorio;
            _propostaRepositorio = propostaRepositorio;
            _mapper = mapper;
        }

        public async Task<IncluirPropostaResposta> Handle(IncluirPropostaRequisicao request, CancellationToken cancellationToken)
        {
            (Proponente proponente, Agente agente, Loja loja) = await ObterEntidadesRelacionadasAsync(request, cancellationToken);

            if(proponente.Propostas.Any(p => !p.Status.FoiFinalizada))
                throw new ProponentePossuiPropostaEmAbertoException("Proponente possui proposta em aberto");

            if(CpfEstaEmListaDeFraudadores(request.CpfProponente))
                throw new ProponenteFraudadorException("Proponente Fraudador");

            if (!agente.Ativo)
                throw new AgenteInativoException("Agente esta inativo");

            if (UfPossuiRestricaoDeValor(loja.Uf, request.ValorSolicitado))
                throw new ValorSolicitadoExcedeLimiteException("Valor solicitado excede o limite permitido para a UF da loja");

            double idadePrepotente = DateTimeOffset.Now.Subtract(proponente.DataNascimento).TotalDays / 365.25;
            double anosPagamento = request.QuantidadeParcelas / 12;

            if (idadePrepotente + anosPagamento > 80)
                throw new IdadeMaximaExcedidaException("Idade maxima para ultimo pagamento excedida");

            if (!loja.Homologada)
                throw new LojaNaoHomologadaException("Loja nao foi homologada");

            Proposta proposta = new Proposta()
            {
                Id = Guid.NewGuid(),
                ValorSolicitado = request.ValorSolicitado,
                QuantidadeParcelas = request.QuantidadeParcelas,
                ValorParcela = request.ValorParcela,
                Data = request.Data,
                Status = StatusPropostaEnum.EmAnalise,
                CpfProponente = request.CpfProponente,
                IdAgente = request.IdAgente,
                IdLoja = request.IdLoja,
                InseridaEm = DateTimeOffset.Now,
            };

            await _propostaRepositorio.InserirAsync(proposta, cancellationToken);

            IncluirPropostaResposta resposta = new IncluirPropostaResposta()
            {
                Proposta = _mapper.Map<PropostaDto>(proposta)
            };

            return resposta;
        }

        private bool UfPossuiRestricaoDeValor(string uf, double valorSolicitado)
            => uf == "RS" && valorSolicitado > 10000;

        private bool CpfEstaEmListaDeFraudadores(string cpfProponente)
        {
            throw new NotImplementedException();
        }

        private async Task<(Proponente proponente, Agente agente, Loja loja)> ObterEntidadesRelacionadasAsync(IncluirPropostaRequisicao request, CancellationToken cancellationToken)
        {
            Proponente proponente = await _proponenteRepositorio.ObterAsync(request.CpfProponente, cancellationToken);

            if (proponente == null)
            {
                proponente = new Proponente()
                {
                    Cpf = request.CpfProponente,
                    Nome = request.Nome,
                    DataNascimento = request.DataNascimento,
                    NumeroInss = request.NumeroInss,
                    ValorAposentadoria = request.ValorAposentadoria,
                    Endereco = request.Endereco,
                    Telefone = request.Telefone,
                    Email = request.Email,
                };

                await _proponenteRepositorio.InserirAsync(proponente, cancellationToken);
            }

            Agente agente = await _agenteRepositorio.ObterAsync(request.IdAgente, cancellationToken);

            if (agente == null)
                throw new AgenteNaoEncontradoException($"Agente com id {request.IdAgente} nao encontrado");

            Loja loja = await _lojaRepositorio.ObterAsync(request.IdLoja, cancellationToken);

            if (loja == null)
                throw new LojaNaoEncontradaException($"Loja com id {request.IdLoja} nao encontrada");

            return (proponente, agente, loja);
        }
    }
}
