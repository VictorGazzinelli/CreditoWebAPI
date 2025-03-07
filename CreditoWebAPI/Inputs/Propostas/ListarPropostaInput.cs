namespace CreditoWebAPI.Inputs.Propostas
{
    public class ListarPropostaInput
    {
        public Guid? IdLoja { get; set; }
        public Guid? IdAgente { get; set; }
        public string? CpfProponente { get; set; }
    }
}
