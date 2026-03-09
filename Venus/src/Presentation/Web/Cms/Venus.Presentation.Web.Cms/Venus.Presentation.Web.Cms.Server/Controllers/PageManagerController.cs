using Microsoft.AspNetCore.Mvc;
using Venus.Core.Application.Features.Cms;
using Venus.Core.Application.Results.Extensions;
using Venus.Presentation.Web.Cms.Server.Controllers.Base;
using Venus.Presentation.Web.Cms.Server.Extensions;
using Venus.Presentation.Web.Cms.Server.Models.PageManagers;

namespace Venus.Presentation.Web.Cms.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PageManagerController : CmsApiControllerBase
    {

        [HttpGet()]
        public async Task<IActionResult> GetPageAbouts()
        {
            var pageAboutList = await base.Mediator.Send(new GetVenusPageAboutQuery());
            return pageAboutList.ToActionResult(this);
        }

        [HttpPost]
        public async Task<IActionResult> UrlCheck([FromBody] string url)
        {
            var checkUrlResult = await base.Mediator.Send(new VenusUrlCheckQuery() { UrlPath = url });
            return checkUrlResult.ToActionResult(this);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePage(CreatePageRequest createPageRequest,CancellationToken cancellationToken)
        {
            var createPageResult = await base.Mediator.Send(new CreateVenusPageCommand() { 
                Title = createPageRequest.Title,
                PageAboutId = createPageRequest.PageAboutId,
                UrlPath = createPageRequest.UrlPath,
                Description = createPageRequest.Description,
                LanguageId = HttpContext.GetLanguageId(),
            }, cancellationToken);
            return createPageResult.ToActionResult(this);
        }

    }
}
 