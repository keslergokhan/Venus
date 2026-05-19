using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Localizations;

namespace Venus.Core.Application.Caching.Interfaces
{
    public interface IVenusLanguageResourceCacheManager : ICacheManager<ReadVenusLanguageResourceKeyDto,string>, ICacheManagerUpload
    {
    }
}
