using Ardalis.SmartEnum;

namespace CreditoWebAPI.Domain.Enums
{
    public class StatusPropostaEnum : SmartEnum<StatusPropostaEnum>
    {
        public static readonly StatusPropostaEnum EmAnalise = new StatusPropostaEnum(nameof(EmAnalise).ToLower(), 1);
        public static readonly StatusPropostaEnum Aprovado = new StatusPropostaEnum(nameof(Aprovado).ToLower(), 2);
        public static readonly StatusPropostaEnum Reprovado = new StatusPropostaEnum(nameof(Reprovado).ToLower(), 3);
        private StatusPropostaEnum(string name, int value) : base(name, value) { }
    }
}
