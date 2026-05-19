using Microsoft.AspNetCore.Mvc;
using Venus.Core.Application.Caching.Interfaces;
using Venus.Core.Application.Caching.Managers;
using Venus.Presentation.Web.Cms.Server.Controllers.Base;

namespace Venus.Presentation.Web.Cms.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationSettingController : CmsApiControllerBase
    {
        private readonly ICacheService cacheService;
        private readonly IVenusConfigurationSettingCacheManager venusConfigurationSettingCacheManager;
        private readonly IVenusLanguageResourceCacheManager venusLanguageResourceCacheManager;

        public ConfigurationSettingController(ICacheService cacheService, IVenusConfigurationSettingCacheManager venusConfigurationSettingCacheManager, IVenusLanguageResourceCacheManager venusLanguageResourceCacheManager)
        {
            this.cacheService = cacheService;
            this.venusConfigurationSettingCacheManager = venusConfigurationSettingCacheManager;
            this.venusLanguageResourceCacheManager = venusLanguageResourceCacheManager;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Set([FromBody]string value)
        {
            await cacheService.SetAsync("config_setting", value);
            return Ok();
        }

        [HttpGet("get")]
        public async Task<IActionResult> Set()
        {
            var varCacheData = await venusConfigurationSettingCacheManager.GetAllAsync();
            var language = await venusLanguageResourceCacheManager.GetAllAsync();
            return Ok(varCacheData);
        }
    }
}
