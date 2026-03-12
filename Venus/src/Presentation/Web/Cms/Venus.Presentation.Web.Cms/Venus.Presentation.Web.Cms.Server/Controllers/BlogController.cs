using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Venus.Presentation.Web.Cms.Server.Controllers.Base;
using Venus.Presentation.Web.Cms.Server.Extensions;
using Venus.Presentation.Web.Cms.Server.Models.Blogs;
using Venus.Presentation.Web.Cms.Server.Extensions;
using Venus.Core.Application.Features.Cms.Entities.Blogs.Commands;
using Venus.Core.Application.Results.Extensions;

namespace Venus.Presentation.Web.Cms.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : CmsApiControllerBase
    {
       
        [HttpPost("create")]
        public async Task<IActionResult> CreateBlog(CreateBlogReq createBlogReq,CancellationToken cancellationToken)
        {
            var createBlogReuslt = await base.Mediator.Send(new CreateBlogCommand()
            {
                Title = createBlogReq.Title,
                Description = createBlogReq.Description,
                JsonData = createBlogReq.JsonData,
                LanguageId = HttpContext.GetLanguageId(),
                UrlPath = createBlogReq.UrlPath 
            },cancellationToken);

            return createBlogReuslt.ToActionResult(this);
        }

    }
}
