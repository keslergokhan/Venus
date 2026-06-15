using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Venus.Core.Application.Features.Cms.Queries;
using Venus.Presentation.Web.Cms.Server.Controllers.Base;
using Venus.Presentation.Web.Cms.Server.Extensions;
using Venus.Core.Application.Results.Extensions;

namespace Venus.Presentation.Web.Cms.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WidgetController : CmsApiControllerBase
    {
        [HttpGet("get-all")]
        public async Task<IActionResult> GetBlogs(CancellationToken cancellationToken)
        {
            var getBlogsResult = await base.Mediator.Send(new GetBlogQuery()
            {
                LanguageId = HttpContext.GetLanguageId(),
            }, cancellationToken);
            return getBlogsResult.ToActionResult(this);
        }
    }
}
