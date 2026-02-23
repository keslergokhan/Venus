using Microsoft.AspNetCore.Mvc;
using Venus.Core.Application.Features.Cms.Pages.Queries;
using Venus.Core.Application.Features.Cms.Url.Queries;
using Venus.Core.Application.Results.Extensions;
using Venus.Presentation.Web.Cms.Server.Controllers.Base;

namespace Venus.Presentation.Web.Cms.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PageManagerController : CmsApiControllerBase
    {

        [HttpGet()]
        public async Task<IActionResult> GetPageAbouts()
        {
            var pageAboutList = await base.Mediator.Send(new VenusGetPageAboutQuery());
            return pageAboutList.ToActionResult(this);
        }

        [HttpPost]
        public async Task<IActionResult> UrlCheck([FromBody] string url)
        {
            var checkUrlResult = await base.Mediator.Send(new VenusUrlCheckQuery() { UrlPath = url });
            return checkUrlResult.ToActionResult(this);
        }

    }
}
 