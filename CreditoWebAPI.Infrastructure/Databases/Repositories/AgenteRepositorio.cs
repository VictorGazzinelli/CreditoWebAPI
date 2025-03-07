using CreditoWebAPI.Application.Interfaces.Repositories;
using CreditoWebAPI.Domain.Entities;

namespace CreditoWebAPI.Infrastructure.Database.Repositories
{
    public class AgenteRepositorio : IAgenteRepositorio
    {
        public Task EditarAsync(Agente agente, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task InserirAsync(Agente agente, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Agente> ObterAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
