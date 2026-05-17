using Microsoft.AspNetCore.Mvc;
using Venus.Core.Application.Caching.Interfaces;
using Venus.Presentation.Web.Cms.Server.Controllers.Base;

namespace Venus.Presentation.Web.Cms.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationSettingController : CmsApiControllerBase
    {
        private readonly ICacheService cacheService;

        public ConfigurationSettingController(ICacheService cacheService)
        {
            this.cacheService = cacheService;
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
            var sss = await cacheService.GetAsync("config_setting");
            return Ok(sss);
        }
    }
}
