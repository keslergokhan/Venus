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

        public ConfigurationSettingController(ICacheService cacheService, IVenusConfigurationSettingCacheManager venusConfigurationSettingCacheManager)
        {
            this.cacheService = cacheService;
            this.venusConfigurationSettingCacheManager = venusConfigurationSettingCacheManager;
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
            var rrr = await venusConfigurationSettingCacheManager.GetAsync("test.2");
            var sss = await cacheService.GetAsync("config_setting");
            return Ok(sss);
        }
    }
}
