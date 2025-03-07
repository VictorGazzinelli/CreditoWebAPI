using CreditoWebAPI.Domain.Entities;

namespace CreditoWebAPI.Application.Interfaces.Repositories
{
    public interface ILojaRepositorio
    {
        Task InserirAsync(Loja loja, CancellationToken cancellationToken);
        Task<Loja> ObterAsync(Guid id, CancellationToken cancellationToken);
        Task EditarAsync(Loja loja, CancellationToken cancellationToken);
    }
}
