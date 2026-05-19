using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Caching.Interfaces;
using Venus.Core.Application.Dtos.Interfaces;

namespace Venus.Core.Application.Caching.Base
{
    public abstract class CacheManagerBase
    {
        protected ICacheService CacheService;
        protected static HashSet<string> AllKeys = new HashSet<string>();
        public CacheManagerBase(ICacheService cacheService)
        {
            CacheService = cacheService;
        }

    }

    public abstract class CacheManagerBase<TDto,TKeyType> : CacheManagerBase, ICacheManager<TDto,TKeyType>, ICacheManagerUpload
        where TDto : IReadDtoBase
    {
        protected CacheManagerBase(ICacheService cacheService) : base(cacheService)
        {
        }

        public string basekey => $"{typeof(TDto).Name}";    

        public HashSet<string> GetKeys()
        {
            return AllKeys.Where(x=>x.StartsWith($"{basekey}:")).ToHashSet();
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

        public async Task<List<TDto>> GetAllAsync()
        {
            List<TDto> result = new List<TDto>();   
            var keys = GetKeys();
            foreach (var key in keys)
            {
                var data = await CacheService.GetAsync<TDto>(key);
                if (data!=null)
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

        public Task<TDto> GetAsync(string key)
        {
            return CacheService.GetAsync<TDto>($"{basekey}:{key}");
        }

    }
}
