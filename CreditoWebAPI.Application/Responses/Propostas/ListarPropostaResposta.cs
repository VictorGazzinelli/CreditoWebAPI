using CreditoWebAPI.Application.Dtos;

namespace CreditoWebAPI.Application.Responses.Propostas
{
    public class ListarPropostaResposta
    {
        public IEnumerable<PropostaDto> Propostas { get; set; }
    }
}
