using CreditoWebAPI.Domain.Entities;

namespace CreditoWebAPI.Application.Interfaces.Repositories
{
    public interface IProponenteRepositorio
    {
        Task InserirAsync(Proponente proponente, CancellationToken cancellationToken);
        Task<Proponente> ObterAsync(string cpf, CancellationToken cancellationToken);
        Task EditarAsync(Proponente proponente, CancellationToken cancellationToken);
    }
}
