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

    public interface ICacheManagerRefresh<TDto, TKeyType> : ICacheManagerUpload
        where TDto : IReadDtoBase
    {
        /// <summary>
        /// Key olarak kullanılacak property'i belirtir. Örneğin, eğer TDto'nun Id property'si key olarak kullanılacaksa, 
        /// GetKeyProperty => x => x.Id şeklinde implement edilir.
        /// </summary>
        protected Func<TDto, TKeyType> GetKeyProperty { get; }
        public Task<TDto> GetOrCreateAsync(TKeyType key);
    }

    public interface ICacheManager<TDto,TKeyType> where TDto : IReadDtoBase
    {
        Task<TDto> GetAsync(TKeyType key);
        Task SetAsync(TDto value);
        Task RemoveAsync(TDto value);
        public Task<List<TDto>> GetAllAsync();
        public HashSet<string> GetKeys();
    }

    public interface IBasicCacheManager<TDto, TKeyType> : ICacheManager<TDto, TKeyType>, ICacheManagerUpload
        where TDto : IReadDtoBase
    {
    }

    public interface IAdvancedCacheManager<TDto, TKeyType> : ICacheManager<TDto, TKeyType>, ICacheManagerRefresh<TDto, TKeyType>, ICacheManagerUpload
        where TDto : IReadDtoBase
    {
    }



}
