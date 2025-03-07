using CreditoWebAPI.Application.Interfaces.Repositories;
using CreditoWebAPI.Domain.Entities;

namespace CreditoWebAPI.Infrastructure.Database.Repositories
{
    public class LojaRepositorio : ILojaRepositorio
    {
        public Task EditarAsync(Loja loja, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task InserirAsync(Loja loja, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Loja> ObterAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
