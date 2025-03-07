namespace CreditoWebAPI.Inputs.Propostas
{
    public class IncluirPropostaInput
    {
        public string CpfProponente { get; set; }
        public Guid IdAgente { get; set; }
        public Guid IdLoja { get; set; }

        public double ValorSolicitado { get; set; }
        public int QuantidadeParcelas { get; set; }
        public double ValorParcela { get; set; }
        public DateTimeOffset Data { get; set; }
    }
}
