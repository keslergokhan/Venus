using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venus.Core.Application.Caching.Base
{
    public abstract class CacheServiceBase
    {
        public static TimeSpan DefaultExpiration { get; set; }
    }
}
