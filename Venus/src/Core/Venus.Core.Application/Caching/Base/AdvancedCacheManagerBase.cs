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
    /// <summary>
    /// <inheritdoc cref="BasicCacheManagerBase{TModel,TKeyType}" path="/summary"/> 
    /// </summary>
    /// <remarks>
    ///     <inheritdoc cref="BasicCacheManagerBase{TModel,TKeyType}" path="/remarks"/> 
    ///     
    ///     <para>
    ///         <see cref="GetOrCreateAsync"/> ile bellekten veri alınmak istenir eğer bellekte veri yoksa <see cref="DataRefreshSourceAction"/> araclığı ile
    ///         veri kaynağından alınır ve aynı veri ön belleğe kayıt edilir.
    ///     </para>
    /// </remarks>
    /// <typeparam name="TModel">
    /// <inheritdoc cref="BasicCacheManagerBase{TModel,TKeyType}" path="/typeparam[@name='TModel']"/>
    /// </typeparam>
    /// <typeparam name="TKeyType">
    /// <inheritdoc cref="BasicCacheManagerBase{TModel,TKeyType}" path="/typeparam[@name='TKeyType']"/>
    /// </typeparam>
    public abstract class AdvancedCacheManagerBase<TModel, TKeyType> : BasicCacheManagerBase<TModel, TKeyType>, IAdvancedCacheManager<TModel, TKeyType>
        where TModel : class,new()
    {
        public AdvancedCacheManagerBase(ICacheService cacheService) : base(cacheService)
        {
        }

        /// <summary>
        /// Eğer bir GetOrCreate mekanizması uygulanacaksa, cache'te bulunmayan bir key için veriyi kaynağından çekmek için kullanılacak fonksiyonu belirtir.
        /// </summary>
        protected abstract Func<TKeyType, Task<TModel>> DataRefreshSourceAction { get; }

        public async Task<TModel> GetOrCreateAsync(TKeyType key)
        {
            if (DataRefreshSourceAction == null)
                throw new VenusCmsBusinessCmsException("Öncelikle veri kaynağının elde edilebilmesi için DataRefreshSourceAction implement edilmelidir.");

            TModel cacheData = await GetAsync(key);
            if (cacheData==null)
            {
                cacheData = await DataRefreshSourceAction(key);
                await SetAsync(cacheData);
            }
            
            return cacheData;
        }

    }
}
