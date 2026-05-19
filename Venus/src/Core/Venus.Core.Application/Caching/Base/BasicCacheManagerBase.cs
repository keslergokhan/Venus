using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Caching.Interfaces;
using Venus.Core.Application.Dtos.Interfaces;
using Venus.Core.Application.Exceptions.Cms;

namespace Venus.Core.Application.Caching.Base
{
    public abstract class BasicCacheManagerBase<TDto, TKeyType> : CacheManagerBase, IBasicCacheManager<TDto, TKeyType>
        where TDto : IReadDtoBase
    {
        protected BasicCacheManagerBase(ICacheService cacheService) : base(cacheService)
        {
        }

        public string basekey => $"{typeof(TDto).Name}";


        public HashSet<string> GetKeys()
        {
            return AllKeys.Where(x => x.StartsWith($"{basekey}:")).ToHashSet();
        }


        /// <summary>
        /// Key olarak kullanılacak property'i belirtir. Örneğin, eğer TDto'nun Id property'si key olarak kullanılacaksa, 
        /// GetKeyProperty => x => x.Id şeklinde implement edilir.
        /// </summary>
        public abstract Func<TDto, TKeyType> GetKeyProperty { get; }
        
        public async Task SetAllAsync(List<TDto> values)
        {
            foreach (var item in values)
            {
                await SetAsync(item);
            }
        }

        public async Task<List<TDto>> GetAllAsync()
        {
            List<TDto> result = new List<TDto>();
            var keys = GetKeys();
            
            foreach (var key in keys)
            {
                var data = await CacheService.GetAsync<TDto>(key);
                if (data != null)
                    result.Add(data);
            }
            return result;
        }

        public Task SetAsync(TDto value)
        {
            string key = $"{basekey}:{GetKeyProperty(value).ToString()}";
            CacheManagerBase.AllKeys.Add(key);
            return CacheService.SetAsync(key, value);
        }

        public Task RemoveAsync(TDto value)
        {
            string key = $"{basekey}:{GetKeyProperty(value).ToString()}";
            CacheManagerBase.AllKeys.Remove(key);
            return CacheService.RemoveAsync(key);
        }


        public Task<TDto> GetAsync(TKeyType key)
        {
            return CacheService.GetAsync<TDto>($"{basekey}:{key.ToString()}");
        }

        public abstract Task DataCacheUploadAsync();

    }
}
