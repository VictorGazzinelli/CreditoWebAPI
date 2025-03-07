namespace CreditoWebAPI.Inputs.Propostas
{
    public class SimularPropostaInput
    {
        public string CpfProponente { get; set; }
        public double ValorSolicitado { get; set; }
        public int QuantidadeParcelas { get; set; }
    }
}
