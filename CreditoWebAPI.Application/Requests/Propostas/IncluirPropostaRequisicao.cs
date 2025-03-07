using CreditoWebAPI.Application.Responses.Propostas;
using MediatR;

namespace CreditoWebAPI.Application.Requests.Propostas
{
    public class IncluirPropostaRequisicao : IRequest<IncluirPropostaResposta>
    {
        public string CpfProponente { get; set; }
        public string Nome { get; set; }
        public DateTimeOffset DataNascimento { get; set; }
        public string NumeroInss { get; set; }
        public double ValorAposentadoria { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public Guid IdAgente { get; set; }
        public Guid IdLoja { get; set; }

        public double ValorSolicitado { get; set; }
        public int QuantidadeParcelas { get; set; }
        public double ValorParcela { get; set; }
        public DateTimeOffset Data { get; set; }
    }
}
