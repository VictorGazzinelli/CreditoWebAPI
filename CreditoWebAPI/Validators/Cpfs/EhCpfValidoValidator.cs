using FluentValidation;
using FluentValidation.Validators;

namespace CreditoWebAPI.Validators.Cpfs
{
    public class EhCpfValidoValidator<TInput> : PropertyValidator<TInput, string>
    {
        public override string Name => "EhCpfValidoValidator";

        public override bool IsValid(ValidationContext<TInput> context, string value)
        {
            string cpf = value;

            if (string.IsNullOrWhiteSpace(cpf))
            {
                return false;
            }

            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            // CPFs que nao possuem 11 digitos são invalidos
            if (cpf.Length != 11)
            {
                return false;
            }

            // CPFs com todos os digitos iguais são invalidos
            if (cpf.Distinct().Count() == 1)
            {
                return false;
            }

            // ToDo: Implementar outras verificações de validacao de CPF

            return true;
        }

        protected override string GetDefaultMessageTemplate(string errorCode)
            => "CPF invalido.";
    }
}
