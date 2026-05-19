using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Caching.Interfaces;
using Venus.Core.Application.Dtos.Interfaces;
using Venus.Core.Application.Exceptions.Cms;

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
}
