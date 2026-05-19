using Microsoft.AspNetCore.Mvc;
using Venus.Core.Application.Caching.Interfaces;
using Venus.Core.Application.Results.Extensions;
using Venus.Presentation.Web.Cms.Server.Controllers.Base;

namespace Venus.Presentation.Web.Cms.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationSettingController : CmsApiControllerBase
    {

      
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new Core.Application.Features.Cms.ConfigurationSettings.Queries.GetConfigurationSettingQuery()
            {
                Hidden = false
            });
            return result.ToActionResult(this);
        }
    }
}
