using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Caching.Base;
using Venus.Core.Application.Caching.Interfaces;

namespace Venus.Core.Application.Caching
{
    public class CacheWarmupService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly PeriodicTimer _periodicTimer;

        public CacheWarmupService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
            _periodicTimer = new PeriodicTimer(CacheServiceBase.DefaultExpiration);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            bool isFirstRun = true;
            while (isFirstRun || await _periodicTimer.WaitForNextTickAsync(stoppingToken) && !stoppingToken.IsCancellationRequested)
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    await CacheRefreshAsync(scope);
                }
                isFirstRun = false;
            }
        }

        private async Task CacheRefreshAsync(IServiceScope scope)
        {
            var cacheManagerList = new List<Type>()
            {
                typeof(IVenusConfigurationSettingCacheManager),
                typeof(IVenusLanguageResourceCacheManager)
            };

            foreach (var itemType in cacheManagerList)
            {
                var cacheManager = scope.ServiceProvider.GetRequiredService(itemType) as ICacheManagerUpload;
                cacheManager.DataCacheUploadAsync().GetAwaiter().GetResult();
            }
            await Task.CompletedTask;
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _periodicTimer.Dispose();
            await base.StopAsync(cancellationToken);
        }
    }
}
