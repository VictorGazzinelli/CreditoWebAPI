using CreditoWebAPI.Application.Requests.Propostas;
using CreditoWebAPI.Application.Responses.Propostas;
using CreditoWebAPI.Inputs.Propostas;
using CreditoWebAPI.Validators.Propostas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CreditoWebAPI.Controllers
{
    public class PropostaController : ApiController
    {
        [HttpPost]
        public async Task<IStatusCodeActionResult> Incluir(IncluirPropostaInput input, CancellationToken cancellationToken)
        {
            Validate<IncluirPropostaInput, IncluirPropostaInputValidator>(input);

            IncluirPropostaRequisicao requisicao = new IncluirPropostaRequisicao()
            {
                CpfProponente = input.CpfProponente,
                IdAgente = input.IdAgente, // Neste caso, o IdAgente e IdLoja são passados como parâmetros, mas poderiam ser obtidos atraves das claims de um token JWT, por exemplo.
                IdLoja = input.IdLoja,
                ValorSolicitado = input.ValorSolicitado,
                QuantidadeParcelas = input.QuantidadeParcelas,
                ValorParcela = input.ValorParcela,
                Data = input.Data,
                DataNascimento = input.DataNascimento,
                Email = input.Email,
                Endereco = input.Endereco,
                Nome = input.Nome,
                NumeroInss = input.NumeroInss,
                Telefone = input.Telefone,
                ValorAposentadoria = input.ValorAposentadoria,
            };

            IncluirPropostaResposta resposta = await Mediator.Send(requisicao, cancellationToken);

            return Ok(resposta);
        }

        [HttpPost]
        public async Task<IStatusCodeActionResult> Simular(SimularPropostaInput input, CancellationToken cancellationToken)
        {
            Validate<SimularPropostaInput, SimularPropostaInputValidator>(input);

            SimularPropostaRequisicao requisicao = new SimularPropostaRequisicao()
            {
                CpfProponente = input.CpfProponente,
                ValorSolicitado = input.ValorSolicitado,
                QuantidadeParcelas = input.QuantidadeParcelas,
            };

            SimularPropostaResposta resposta = await Mediator.Send(requisicao, cancellationToken);

            return Ok(resposta);
        }

        [HttpPut]
        public async Task<IStatusCodeActionResult> Validar(ValidarPropostaInput input, CancellationToken cancellationToken)
        {
            ValidarPropostaRequisicao requisicao = new ValidarPropostaRequisicao()
            {
                Id = input.Id,
            };

            ValidarPropostaResposta resposta = await Mediator.Send(requisicao, cancellationToken);

            return Ok(resposta);
        }

        [HttpPost]
        public async Task<IStatusCodeActionResult> Processar(ProcessarPropostaInput input, CancellationToken cancellationToken)
        {
            ProcessarPropostaRequisicao requisicao = new ProcessarPropostaRequisicao()
            {
                Id = input.Id,
            };

            await Mediator.Send(requisicao, cancellationToken);

            return Ok();
        }

        [HttpGet]
        public async Task<IStatusCodeActionResult> Obter([FromQuery] ObterPropostaInput input, CancellationToken cancellationToken)
        {
            ObterPropostaRequisicao requisicao = new ObterPropostaRequisicao()
            {
                Id = input.Id,
            };

            ObterPropostaResposta resposta = await Mediator.Send(requisicao, cancellationToken);

            return Ok(resposta);
        }

        [HttpGet]
        public async Task<IStatusCodeActionResult> Listar(CancellationToken cancellationToken)
        {
            ListarPropostaRequisicao requisicao = new ListarPropostaRequisicao();

            ListarPropostaResposta resposta = await Mediator.Send(requisicao, cancellationToken);

            return Ok(resposta);
        }

    }
}
