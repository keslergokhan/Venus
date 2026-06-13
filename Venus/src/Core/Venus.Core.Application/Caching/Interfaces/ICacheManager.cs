using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Caching.Interfaces;
using Venus.Core.Application.Dtos.Interfaces;

namespace Venus.Core.Application.Caching.Interfaces
{
    public interface ICacheManagerUpload
    {
        /// <summary>
        /// Toplu veri cache'e yüklemek için kullanılır. Örneğin, uygulama başladığında veya belirli aralıklarla veritabanından tüm verileri çekip cache'e yüklemek için bu method implement edilir.
        /// </summary>
        /// <returns></returns>
        Task DataCacheUploadAsync();
    }

    public interface ICacheManagerRefresh<TModel, TKeyType> : ICacheManagerUpload
        where TModel : class,new()
    {
        /// <summary>
        /// Key olarak kullanılacak property'i belirtir. Örneğin, eğer TModel'nun Id property'si key olarak kullanılacaksa, 
        /// GetKeyProperty => x => x.Id şeklinde implement edilir.
        /// </summary>
        protected Func<TModel, TKeyType> GetKeyProperty { get; }
        public Task<TModel> GetOrCreateAsync(TKeyType key);
    }

    public interface ICacheManager<TModel,TKeyType> where TModel : class, new()
    {
        Task<TModel> GetAsync(TKeyType key);
        Task SetAsync(TModel value);
        Task RemoveAsync(TModel value);
        public Task<List<TModel>> GetAllAsync();
        public HashSet<string> GetKeys();
    }

    public interface IBasicCacheManager<TModel, TKeyType> : ICacheManager<TModel, TKeyType>, ICacheManagerUpload
        where TModel : class, new()
    {
    }

    public interface IAdvancedCacheManager<TModel, TKeyType> : ICacheManager<TModel, TKeyType>, ICacheManagerRefresh<TModel, TKeyType>, ICacheManagerUpload
        where TModel : class, new()
    {
    }



}
