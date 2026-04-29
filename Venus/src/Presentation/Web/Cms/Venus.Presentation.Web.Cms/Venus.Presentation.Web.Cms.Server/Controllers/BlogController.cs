using Microsoft.AspNetCore.Mvc;
using Venus.Core.Application.Features.Cms;
using Venus.Core.Application.Features.Cms.Entities.Blogs.Queries;
using Venus.Core.Application.Features.Systems.Pages.Queries;
using Venus.Core.Application.Results.Extensions;
using Venus.Presentation.Web.Cms.Server.Controllers.Base;
using Venus.Presentation.Web.Cms.Server.Extensions;
using Venus.Presentation.Web.Cms.Server.Models.Blogs;

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
                DynamicProperties = createBlogReq.DynamicProperties,
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

        [HttpGet("get-page")]
        public async Task<IActionResult> GetBasePath()
        {
            var basePath = await base.Mediator.Send(new GetEntityDetailVenusPageByEntityName()
            {
                EntityTypeFullName = "Venus.Core.Domain.Entities.Blog",
                LanguageId = HttpContext.GetLanguageId()
            });

            return basePath.ToActionResult(this);
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
