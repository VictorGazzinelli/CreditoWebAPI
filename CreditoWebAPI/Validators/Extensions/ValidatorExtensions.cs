using CreditoWebAPI.Validators.Cpfs;
using FluentValidation;

namespace CreditoWebAPI.Validators.Extensions
{
    public static class ValidatorExtensions
    {
        public static IRuleBuilderOptions<T, string> RepresentaCpfValido<T>(this IRuleBuilder<T, string> ruleBuilder) =>
            ruleBuilder.SetValidator(new EhCpfValidoValidator<T>());

        public static IRuleBuilderOptions<T, double> RepresentaValorMonetarioValido<T>(this IRuleBuilder<T, double> ruleBuilder) =>
            ruleBuilder.SetValidator(new EhValorMonetarioValidoValidator<T>());
    }
}
