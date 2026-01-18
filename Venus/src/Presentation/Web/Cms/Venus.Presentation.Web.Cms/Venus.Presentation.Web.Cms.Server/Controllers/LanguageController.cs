using Microsoft.AspNetCore.Mvc;
using Venus.Core.Application.Dtos.Systems.Languages;
using Venus.Core.Application.Features.Cms.Languages.Queries;
using Venus.Core.Application.Results.Extensions;
using Venus.Presentation.Web.Cms.Server.Controllers.Base;
using Venus.Presentation.Web.Cms.Server.Models.Languages;

namespace Venus.Presentation.Web.Cms.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LanguageController : CmsApiControllerBase
    {
        public static List<ReadVenusLanguageDto> LanguagesCache = new List<ReadVenusLanguageDto>();

        [HttpPost]
        public async Task<IActionResult> SetLanguage([FromBody] SetLanguageReq req)
        {
            var result = await base.Mediator.Send(new VenusGetLanguageQuery());

            return result.ToActionResult(this);
        }

        [HttpPost]
        public async Task<IActionResult> GetLanguage()
        {
            var result = await base.Mediator.Send(new VenusGetLanguageQuery());

            if (result.IsSuccess)
            {
                LanguageController.LanguagesCache = result.Data;
            }

            return result.ToActionResult(this);
        }

    }
}
