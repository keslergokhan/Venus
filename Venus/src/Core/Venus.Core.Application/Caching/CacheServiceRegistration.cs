using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Venus.Core.Application.Caching.Base;
using Venus.Core.Application.Caching.Interfaces;
using Venus.Core.Application.Caching.Managers;
using Venus.Core.Application.Caching.Services;

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
            services.AddScoped<IVenusLanguageResourceCacheManager, VenusLanguageResourceCacheManager>();

            services.AddMemoryCache(options =>
            {
                options.CompactionPercentage = 0.20;
                options.ExpirationScanFrequency = TimeSpan.FromMinutes(5);
            });

            services.AddHostedService<CacheWarmupService>();
            return services;
        }
    }
}
