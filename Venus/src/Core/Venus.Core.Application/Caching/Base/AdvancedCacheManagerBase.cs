using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Caching.Interfaces;
using Venus.Core.Application.Dtos.Interfaces;
using Venus.Core.Application.Exceptions.Cms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Venus.Core.Application.Caching.Base
{
    public abstract class AdvancedCacheManagerBase<TDto, TKeyType> : BasicCacheManagerBase<TDto, TKeyType>, IAdvancedCacheManager<TDto, TKeyType>
        where TDto : IReadDtoBase
    {
        public AdvancedCacheManagerBase(ICacheService cacheService) : base(cacheService)
        {
        }

        /// <summary>
        /// Eğer bir GetOrCreate mekanizması uygulanacaksa, cache'te bulunmayan bir key için veriyi kaynağından çekmek için kullanılacak fonksiyonu belirtir.
        /// </summary>
        protected abstract Func<TKeyType, Task<TDto>> DataRefreshSourceAction { get; }

        public async Task<TDto> GetOrCreateAsync(TKeyType key)
        {
            if (DataRefreshSourceAction == null)
                throw new VenusCmsBusinessCmsException("Öncelikle veri kaynağının elde edilebilmesi için DataRefreshSourceAction implement edilmelidir.");

            TDto cacheData = await GetAsync(key);
            if (cacheData==null)
            {
                cacheData = await DataRefreshSourceAction(key);
                await SetAsync(cacheData);
            }
            
            return cacheData;
        }

    }
}
