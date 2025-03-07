using Ardalis.SmartEnum;

namespace CreditoWebAPI.Domain.Enums
{
    public class StatusPorpostaEnum : SmartEnum<StatusPorpostaEnum>
    {
        public static readonly StatusPorpostaEnum EmAnalise = new StatusPorpostaEnum(nameof(EmAnalise).ToLower(), 1);
        public static readonly StatusPorpostaEnum Aprovado = new StatusPorpostaEnum(nameof(Aprovado).ToLower(), 2);
        public static readonly StatusPorpostaEnum Reprovado = new StatusPorpostaEnum(nameof(Reprovado).ToLower(), 3);
        private StatusPorpostaEnum(string name, int value) : base(name, value) { }
    }
}
