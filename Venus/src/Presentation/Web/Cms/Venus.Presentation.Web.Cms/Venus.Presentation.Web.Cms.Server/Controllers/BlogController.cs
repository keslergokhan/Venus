using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Venus.Presentation.Web.Cms.Server.Controllers.Base;
using Venus.Presentation.Web.Cms.Server.Extensions;
using Venus.Presentation.Web.Cms.Server.Models.Blogs;
using Venus.Core.Application.Features.Cms;
using Venus.Core.Application.Results.Extensions;
using Venus.Core.Application.Features.Cms.Entities.Blogs.Queries;

namespace Venus.Presentation.Web.Cms.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : CmsApiControllerBase
    {

        [HttpPost("create")]
        public async Task<IActionResult> CreateBlog([FromBody] CreateBlogReq createBlogReq, CancellationToken cancellationToken)
        {
            var createBlogReuslt = await base.Mediator.Send(new CreateBlogCommand()
            {
                Title = createBlogReq.Title,
                Description = createBlogReq.Description,
                JsonData = createBlogReq.JsonData,
                LanguageId = HttpContext.GetLanguageId(),
                UrlPath = createBlogReq.UrlPath
            }, cancellationToken);

            return createBlogReuslt.ToActionResult(this);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetBlogs(CancellationToken cancellationToken)
        {
            var getBlogsResult = await base.Mediator.Send(new GetBlogQuery()
            {
                LanguageId = HttpContext.GetLanguageId(),
            }, cancellationToken);
            return getBlogsResult.ToActionResult(this);
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetBlog([FromQuery] Guid id, CancellationToken cancellationToken)
        {
            var getBlogsResult = await base.Mediator.Send(new GetBlogByIdQuery()
            {
                Id = id,
            }, cancellationToken);
            return getBlogsResult.ToActionResult(this);
        }


        [HttpPost("remove")]
        public async Task<IActionResult> RemoveBlog([FromBody] Guid id, CancellationToken cancellationToken)
        {
            var removeBlogResult = await base.Mediator.Send(new RemoveBlogCommand()
            {
                Id = id
            }, cancellationToken);
            return removeBlogResult.ToActionResult(this);
        }
    }
}
