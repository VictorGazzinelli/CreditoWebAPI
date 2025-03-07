using CreditoWebAPI.Inputs.Propostas;
using CreditoWebAPI.Validators.Extensions;
using FluentValidation;

namespace CreditoWebAPI.Validators.Propostas
{
    public class IncluirPropostaInputValidator : AbstractValidator<IncluirPropostaInput>
    {
        public IncluirPropostaInputValidator()
        {
            RuleFor(input => input.CpfProponente)
                .RepresentaCpfValido();

            RuleFor(input => input.ValorSolicitado)
                .RepresentaValorMonetarioValido();

            RuleFor(input => input.QuantidadeParcelas)
                .GreaterThan(0)
                .WithMessage("A quantidade de parcelas deve ser maior que zero.");

            RuleFor(input => input.ValorParcela)
                .RepresentaValorMonetarioValido();
        }
    }
}
