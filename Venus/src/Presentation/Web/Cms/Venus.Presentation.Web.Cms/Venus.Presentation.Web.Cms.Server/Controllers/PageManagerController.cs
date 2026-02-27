using Microsoft.AspNetCore.Mvc;
using Venus.Core.Application.Features.Cms.Pages.Commands;
using Venus.Core.Application.Features.Cms.Pages.Queries;
using Venus.Core.Application.Features.Cms.Url.Queries;
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
                LanguageId = new Guid("DEBE8454-EFAF-449A-B357-32B027A4D61F")
            }, cancellationToken);
            return createPageResult.ToActionResult(this);
        }

    }
}
 