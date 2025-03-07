using System;
using System.Collections.Generic;

namespace CreditoWebAPI.Domain.Entities
{
    public class Loja
    {
        public Guid Id { get; set; } 
        public string Nome { get; set; } 
        public string Endereco { get; set; } 
        public string Uf { get; set; }

        public ICollection<Proposta> Propostas { get; set; }

    }
}
