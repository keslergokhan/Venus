using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venus.Core.Application.Caching.Interfaces
{
    /// <summary>
    /// Temel cache arayüzü
    /// </summary>
    public interface ICacheService
    {
        Task<string> GetAsync(string key);
        Task<T> GetAsync<T>(string key);
        Task SetAsync<T>(string key, T value);
        Task SetAsync<T>(string key, T value, TimeSpan absoluteExpiration, TimeSpan? slidingExpiration = null);
        Task RemoveAsync(string key);
    }
}
