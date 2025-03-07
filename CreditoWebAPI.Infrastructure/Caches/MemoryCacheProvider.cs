using Microsoft.Extensions.Caching.Memory;
using Polly.Caching;

namespace CreditoWebAPI.Infrastructure.Caches
{
    public class MemoryCacheProvider : IAsyncCacheProvider
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheProvider(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Task<(bool, object)> TryGetAsync(string key, CancellationToken cancellationToken = default, bool continueOnCapturedContext = false)
        {
            var result = _memoryCache.TryGetValue(key, out var value);
            return Task.FromResult((result, value));
        }

        public Task PutAsync(string key, object value, Ttl ttl, CancellationToken cancellationToken = default, bool continueOnCapturedContext = false)
        {
            MemoryCacheEntryOptions cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = ttl.Timespan
            };
            _memoryCache.Set(key, value, cacheEntryOptions);
            return Task.CompletedTask;
        }
    }
}
