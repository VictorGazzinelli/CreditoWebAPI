using CreditoWebAPI.Application.Interfaces.Repositories;
using CreditoWebAPI.Domain.Entities;

namespace CreditoWebAPI.Infrastructure.Database.Repositories
{
    public class ProponenteRepositorio : IProponenteRepositorio
    {
        public Task EditarAsync(Proponente proponente, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task InserirAsync(Proponente proponente, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Proponente> ObterAsync(string cpf, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
