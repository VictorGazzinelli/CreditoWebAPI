using CreditoWebAPI.Application.Dtos;
using CreditoWebAPI.Application.Requests.Propostas;
using CreditoWebAPI.Inputs.Propostas;
using CreditoWebAPI.Responses;
using CreditoWebAPI.Validators.Propostas;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CreditoWebAPI.Controllers
{
    public class PropostaController : ApiController
    {
        public PropostaController()
        {

        }

        [HttpPost]
        public async Task<IStatusCodeActionResult> Incluir(IncluirPropostaInput input, CancellationToken cancellationToken)
        {
            IncluirPropostaInputValidator inputValidator = new IncluirPropostaInputValidator();

            ValidationResult validationResult = inputValidator.Validate(input);

            if (!validationResult.IsValid)
                return CreatePropostaInvalidaResponse(validationResult.ToDictionary());

            IncluirPropostaRequisicao requisicao = new IncluirPropostaRequisicao()
            {
                CpfProponente = input.CpfProponente,
                IdAgente = input.IdAgente, // Neste caso, o IdAgente e IdLoja são passados como parâmetros, mas poderiam ser obtidos atraves das claims de um token JWT, por exemplo.
                IdLoja = input.IdLoja,
                ValorSolicitado = input.ValorSolicitado,
                QuantidadeParcelas = input.QuantidadeParcelas,
                ValorParcela = input.ValorParcela,
                Data = input.Data
            };

            PropostaValidaDto proposta = (await Mediator.Send(requisicao, cancellationToken)).Proposta;

            if (!proposta.EhValida)
                return CreatePropostaInvalidaResponse();

            return Accepted(proposta);
        }

        private IStatusCodeActionResult CreatePropostaInvalidaResponse(IDictionary<string, string[]> errors = null)
            => BadRequest(new BadRequestResponse() { Errors = errors ?? new Dictionary<string, string[]>() { { "Proposta", ["Proposta invalida"] } } });
    }
}
