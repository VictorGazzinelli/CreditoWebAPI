using System;
using System.Collections.Generic;

namespace CreditoWebAPI.Domain.Entities
{
    public class Agente
    {
        public Guid Id { get; set; } 
        public string Nome { get; set; }
        public string NumeroRegistroProfissional { get; set; }
        public string Cpf { get; set; } 
        public bool Ativo { get; set; } 

        public ICollection<Proposta> Propostas { get; set; }
    }
}
