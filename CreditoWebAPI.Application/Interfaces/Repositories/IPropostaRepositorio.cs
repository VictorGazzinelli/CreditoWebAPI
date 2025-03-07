using CreditoWebAPI.Domain.Entities;
using System.Linq.Expressions;

namespace CreditoWebAPI.Application.Interfaces.Repositories
{
    public interface IPropostaRepositorio
    {
        Task InserirAsync(Proposta proposta, CancellationToken cancellationToken);
        Task<Proposta> ObterAsync(Guid id, CancellationToken cancellationToken);
        Task EditarAsync(Proposta proposta, CancellationToken cancellationToken);
        Task<IQueryable<Proposta>> ListarAsync(Expression<Func<Proposta, bool>> predicate, CancellationToken cancellationToken);
    }
}
