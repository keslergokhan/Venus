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
    /// <summary>
    /// Belirli bir nesne yapısına özel önbellek yönetimi sunar.
    /// </summary>
    /// 
    /// <remarks>
    ///     <para> 
    ///         <see cref="BasicCacheManagerBase{TModel, TKeyType}"/> alt sınıfları otomaitk olarak <see cref="ICacheManagerUpload"/> implemente edilmesi sağlanır.
    ///         <see cref="Venus.Core.Application.Caching.CacheWarmupService"/> BackgroundService servis araclığı ile sistem ayağa kalktığında otomatik olarak verilerin
    ///         önbelleğe alınmasını sağlar.
    ///     </para>
    ///     <para>
    ///         Ön belleğe alınırken verilerin hangi key değerlerine sahip olacağı dinamik olarak belirlenebilir, <typeparamref name="TKeyType"/> belirtilen tip 
    ///         <see cref="GetKeyProperty"/> override edilerek <typeparamref name="TModel"/> içerisinden seçilir.
    ///     </para>
    /// </remarks>
    /// 
    /// <typeparam name="TModel">Önbelleğe alınacak nesne</typeparam>
    /// <typeparam name="TKeyType">
    ///     Önbelleğe alınırken key değerini temsile edecek olan yapının tipi<br></br>
    ///     Önbelleğe alınırken key=data mantığı üzerine veriler depolanır, burada key olarak <typeparamref name="TModel"/> üzerinden hangi özelliği
    ///     seçeceğimizi belirtiriz<br></br>
    ///     Tavsiye:
    ///     <list type="number">
    ///         <item><see cref=""/><see cref="Guid"/></item>
    ///         <item><see cref=""/><see cref="string"/></item>
    ///         <item><see cref=""/><see cref="int"/></item>
    ///     </list>
    /// </typeparam>
    public abstract class BasicCacheManagerBase<TModel, TKeyType> : CacheManagerBase, IBasicCacheManager<TModel, TKeyType>
        where TModel : class,new()
    {
        protected BasicCacheManagerBase(ICacheService cacheService) : base(cacheService)
        {
        }

        public string basekey => $"{typeof(TModel).Name}";


        public HashSet<string> GetKeys()
        {
            return AllKeys.Where(x => x.StartsWith($"{basekey}:")).ToHashSet();
        }


        /// <summary>
        /// Key olarak kullanılacak property'i belirtir. Örneğin, eğer TModel'nun Id property'si key olarak kullanılacaksa, 
        /// GetKeyProperty => x => x.Id şeklinde implement edilir.
        /// </summary>
        public abstract Func<TModel, TKeyType> GetKeyProperty { get; }
        
        public async Task SetAllAsync(List<TModel> values)
        {
            foreach (var item in values)
            {
                await SetAsync(item);
            }
        }

        public async Task<List<TModel>> GetAllAsync()
        {
            List<TModel> result = new List<TModel>();
            var keys = GetKeys();

            if (keys.Count == 0)
            {
                await DataCacheUploadAsync();
                keys = GetKeys();
            }

            foreach (var key in keys)
            {
                var data = await CacheService.GetAsync<TModel>(key);
                if (data != null)
                    result.Add(data);
            }
            return result;
        }

        public Task SetAsync(TModel value)
        {
            string key = $"{basekey}:{GetKeyProperty(value).ToString()}";
            CacheManagerBase.AllKeys.Add(key);
            return CacheService.SetAsync(key, value);
        }

        public Task RemoveAsync(TModel value)
        {
            string key = $"{basekey}:{GetKeyProperty(value).ToString()}";
            CacheManagerBase.AllKeys.Remove(key);
            return CacheService.RemoveAsync(key);
        }


        public Task<TModel> GetAsync(TKeyType key)
        {
            return CacheService.GetAsync<TModel>($"{basekey}:{key.ToString()}");
        }

        public abstract Task DataCacheUploadAsync();

    }
}
