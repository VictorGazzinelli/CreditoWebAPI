using CreditoWebAPI.Application.Interfaces.Services;
using CreditoWebAPI.Infrastructure.Caches;
using Microsoft.Extensions.Caching.Memory;
using Polly;
using Polly.Caching;
using Polly.Retry;

namespace CreditoWebAPI.Infrastructure.Services
{
    public class TaxaJurosServico : ITaxaJurosServico
    {
        // Este método retorna a taxa de juros ao ano para um proponente
        // Como esta aplicação é apenas um exemplo, a taxa de juros é fixa em 12% ao ano.
        // Em um ambiente real, provavelmente esta informação seria obtida de um serviço externo, que atende a um SLA.
        // Afim de manter a resiliencia da aplicação, é importante que o serviço de taxa de juros seja implementado de forma a tratar falhas de comunicação, como timeouts, erros de rede, etc.
        // Para fins de demonstração, este método simula um erro com uma probabilidade de 5% (5 em 100).
        // Para fins de resiliencia, esse servico tambem conta com uma politica de retry e cache.

        private readonly Random _random = new Random();
        private readonly AsyncRetryPolicy<double> _retryPolicy;
        private readonly AsyncCachePolicy<double> _cachePolicy;
        private readonly AsyncPolicy<double> _fallbackPolicy;
        private readonly IAsyncCacheProvider _cacheProvider;

        public TaxaJurosServico()
        {
            _retryPolicy = Policy<double>
                .HandleResult(-1) // Trata o valor 0 como um erro
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
            _cacheProvider = new MemoryCacheProvider(new MemoryCache(new MemoryCacheOptions()));
            _cachePolicy = Policy.CacheAsync<double>(_cacheProvider, TimeSpan.FromMinutes(5));
            _fallbackPolicy = Policy<double>
                .Handle<Exception>()
                .OrResult(result => result == -1) // Captura o valor -1 como falha
                .FallbackAsync(0.12); // Define o valor de fallback como 0.12
        }


        public async Task<double> ObterTaxaJurosAoAnoAsync(string cpfProponente)
        {
            var policyWrap = Policy.WrapAsync(_cachePolicy, _retryPolicy, _fallbackPolicy);

            return await policyWrap.ExecuteAsync(async (context) =>
            {
                var taxaJuros = await ObterTaxaJurosAoAnoComPotencialFalhaAsync();

                if (taxaJuros == -1)
                {
                    throw new InvalidOperationException("Valor inválido retornado.");
                }

                return taxaJuros;
            }, new Context(cpfProponente)); // Usa o CPF como chave 
        }

        private async Task<double> ObterTaxaJurosAoAnoComPotencialFalhaAsync()
        {
            // Gera um número aleatório entre 0 e 99
            int numeroAleatorio = _random.Next(100);

            // retorna um valor invalido em uma probabilidade de 5% (5 em 100)
            if (numeroAleatorio < 5)
            {
                return -1;
            }

            // Simula uma operação assíncrona
            await Task.Delay(100); // Simula um delay de rede

            return 0.12;
        }
    }
}
