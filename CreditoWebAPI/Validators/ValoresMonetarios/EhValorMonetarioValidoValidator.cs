using FluentValidation;
using FluentValidation.Validators;

namespace CreditoWebAPI.Validators.Cpfs
{
    public class EhValorMonetarioValidoValidator<TInput> : PropertyValidator<TInput, double>
    {
        public override string Name => "EhValorMonetarioValidoValidator";

        public override bool IsValid(ValidationContext<TInput> context, double value)
        {
            double valorMonetario = value;

            // ToDo: Implementar outras verificações de valor monetário. Avaliar tambem casos de borda como double.MaxValue e double.MinValue.
            // Avaliar tambem a possibilidade de utilizar um valor monetário em long para casos onde o valor e incrivelmente alto.

            return valorMonetario > 0;
        }

        protected override string GetDefaultMessageTemplate(string errorCode)
            => "Valor invalido.";
    }
}
