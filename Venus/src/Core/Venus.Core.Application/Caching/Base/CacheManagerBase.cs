using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Caching.Interfaces;
using Venus.Core.Application.Dtos.Interfaces;

namespace Venus.Core.Application.Caching.Base
{
    public abstract class CacheManagerBase<TDto,TKeyType> : ICacheManager<TDto,TKeyType>, ICacheManagerUpload
        where TDto : IReadDtoBase
    {
        protected ICacheService CacheService;

        public CacheManagerBase(ICacheService cacheService)
        {
            CacheService = cacheService;
        }

        public abstract Task DataCacheUploadAsync();

        public abstract Func<TDto, TKeyType> GetKeyProperty { get; }

        public async Task SetAllAsync(List<TDto> values)
        {
            foreach (var item in values)
            {
                await SetAsync(item);
            }
        }

        public Task SetAsync(TDto value)
        {
            return CacheService.SetAsync($"{nameof(TDto)}_{GetKeyProperty(value).ToString()}", value);
        }

        public Task RemoveAsync(TDto value)
        {
            return CacheService.RemoveAsync($"{nameof(TDto)}_{GetKeyProperty(value).ToString()}");
        }

        public Task<TDto> GetAsync(string key)
        {
            return CacheService.GetAsync<TDto>($"{nameof(TDto)}_{key}");
        }

    }
}
