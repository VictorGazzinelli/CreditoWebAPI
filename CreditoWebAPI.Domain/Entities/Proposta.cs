using CreditoWebAPI.Domain.Enums;
using System;

namespace CreditoWebAPI.Domain.Entities
{
    public class Proposta
    {
        public Guid Id { get; set; }
        public double ValorSolicitado { get; set; } 
        public int QuantidadeParcelas { get; set; } 
        public double ValorParcela { get; set; } 
        public DateTimeOffset Data { get; set; } 
        public StatusPorpostaEnum Status { get; set; }

        public DateTimeOffset InseridaEm { get; set; }
        public DateTimeOffset? ConcluidaEm { get; set; }

        public string CpfProponente { get; set; }
        public Guid IdAgente { get; set; } 
        public Guid IdLoja { get; set; }

        public Proponente Proponente { get; set; } 
        public Agente Agente { get; set; } 
        public Loja Loja { get; set; }
    }
}
