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
        Task DataCacheUploadAsync();
    }
    public interface ICacheManager<TDto,TKeyType> where TDto : IReadDtoBase
    {
        Task<TDto> GetAsync(string key);
        Task SetAsync(TDto value);
        Task RemoveAsync(TDto value);
    }
}
