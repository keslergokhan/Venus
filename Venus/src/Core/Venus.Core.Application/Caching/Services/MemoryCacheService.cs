using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Caching.Base;
using Venus.Core.Application.Caching.Interfaces;

namespace Venus.Core.Application.Caching.Services
{
    public class MemoryCacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<T> GetAsync<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public Task<string> GetAsync(string key)
        {
            return GetAsync<string>(key);
        }

        public async Task RemoveAsync(string key)
        {
            _memoryCache.Remove(key);
        }

        public async Task SetAsync<T>(string key, T value)
        {
            _memoryCache.Set(key, value, CacheServiceBase.DefaultExpiration);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan absoluteExpiration, TimeSpan? slidingExpiration = null)
        {
            _memoryCache.Set(key, value, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = absoluteExpiration,
                SlidingExpiration = slidingExpiration
            }); 
        }
      
    }
}
