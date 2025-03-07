using Ardalis.SmartEnum;

namespace CreditoWebAPI.Domain.Enums
{
    public class StatusPropostaEnum : SmartEnum<StatusPropostaEnum>
    {
        public static readonly StatusPropostaEnum EmAnalise = new StatusPropostaEnum(nameof(EmAnalise).ToLower(), 1);
        public static readonly StatusPropostaEnum Aprovada = new StatusPropostaEnum(nameof(Aprovada).ToLower(), 2);
        public static readonly StatusPropostaEnum Reprovada = new StatusPropostaEnum(nameof(Reprovada).ToLower(), 3);

        public bool FoiFinalizada => this == Aprovada || this == Reprovada;

        private StatusPropostaEnum(string name, int value) : base(name, value) { }
    }
}
