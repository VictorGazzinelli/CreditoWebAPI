using CreditoWebAPI.Domain.Entities;

namespace CreditoWebAPI.Application.Interfaces.Repositories
{
    public interface IAgenteRepositorio
    {
        Task InserirAsync(Agente agente, CancellationToken cancellationToken);
        Task<Agente> ObterAsync(Guid id, CancellationToken cancellationToken);
        Task EditarAsync(Agente agente, CancellationToken cancellationToken);
    }
}
