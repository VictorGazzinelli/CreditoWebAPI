using System;
using System.Collections.Generic;

namespace CreditoWebAPI.Domain.Entities
{
    public class Proponente
    {
        public string Cpf { get; set; } 
        public string Nome { get; set; } 
        public DateTimeOffset DataNascimento { get; set; }
        public double ValorAposentadoria { get; set; } 
        public string NumeroInss { get; set; } 
        public string Endereco { get; set; } 
        public string Telefone { get; set; } 
        public string Email { get; set; } 

        public ICollection<Proposta> Propostas { get; set; } 
    }
}
