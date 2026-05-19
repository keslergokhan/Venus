using Microsoft.AspNetCore.Mvc;
using Venus.Core.Application.Caching.Interfaces;
using Venus.Presentation.Web.Cms.Server.Controllers.Base;

namespace Venus.Presentation.Web.Cms.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationSettingController : CmsApiControllerBase
    {
        private readonly IVenusConfigurationSettingCacheManager _venusConfigurationSettingCacheManager;
        private readonly IVenusLanguageResourceCacheManager _venusLanguageResourceCacheManager;

        public ConfigurationSettingController(IVenusConfigurationSettingCacheManager venusConfigurationSettingCacheManager, IVenusLanguageResourceCacheManager venusLanguageResourceCacheManager)
        {
            _venusConfigurationSettingCacheManager = venusConfigurationSettingCacheManager;
            _venusLanguageResourceCacheManager = venusLanguageResourceCacheManager;
        }

      

        [HttpGet("get-all")]
        public async Task<IActionResult> Set()
        {
            var varCacheData = await _venusConfigurationSettingCacheManager.GetAllAsync();
            return Ok(varCacheData);
        }
    }
}
