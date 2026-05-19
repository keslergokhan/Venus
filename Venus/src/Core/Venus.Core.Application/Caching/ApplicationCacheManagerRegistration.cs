using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Caching.Interfaces;
using Venus.Core.Application.Dtos.Systems.Settings;

namespace Venus.Core.Application.Caching
{
    public static class ApplicationCacheManagerRegistration
    {
        public static void AddApplicationCacheManager(this IApplicationBuilder applicationBuilder)
        {
            var cacheManagerList = new List<Type>()
            {
                typeof(IVenusConfigurationSettingCacheManager)
            };

            using (var scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                foreach (var itemType in cacheManagerList)
                {
                    var cacheManager = scope.ServiceProvider.GetRequiredService(itemType) as ICacheManagerUpload;
                    cacheManager.DataCacheUploadAsync().GetAwaiter().GetResult();
                }
                
            }
        }
    }
}
