using CreditoWebAPI.Application.Interfaces.Repositories;
using CreditoWebAPI.Domain.Entities;
using System.Linq.Expressions;

namespace CreditoWebAPI.Infrastructure.Database.Repositories
{
    public class PropostaRepositorio : IPropostaRepositorio
    {
        public Task EditarAsync(Proposta proposta, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task InserirAsync(Proposta proposta, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Proposta> ObterAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Proposta>> ListarAsync(Expression<Func<Proposta, bool>> predicate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
