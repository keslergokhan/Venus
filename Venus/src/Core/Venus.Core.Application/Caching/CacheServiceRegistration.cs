using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Caching.Base;
using Venus.Core.Application.Caching.Interfaces;
using Venus.Core.Application.Caching.Managers;
using Venus.Core.Application.Caching.Services;
using Venus.Core.Application.Dtos.Systems.Settings;

namespace Venus.Core.Application.Caching
{
    public static  class CachingServiceRegistration
    {
        public static IServiceCollection AddVenusMemoryCacheRegistration(this IServiceCollection services, IConfiguration configuration,TimeSpan defaultExpiration)
        {
            CacheServiceBase.DefaultExpiration = defaultExpiration;
            services.AddMemoryCache();
            services.AddScoped<ICacheService, MemoryCacheService>();
            services.AddScoped<IVenusConfigurationSettingCacheManager, VenusConfigurationSettingCacheManager>();

            services.AddMemoryCache(options =>
            {
                options.CompactionPercentage = 0.20;
                options.ExpirationScanFrequency = TimeSpan.FromMinutes(5);
            });

            return services;
        }
    }
}
