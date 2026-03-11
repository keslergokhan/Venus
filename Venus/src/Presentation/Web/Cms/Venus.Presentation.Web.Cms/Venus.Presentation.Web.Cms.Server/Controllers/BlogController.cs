using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Venus.Presentation.Web.Cms.Server.Controllers.Base;
using Venus.Presentation.Web.Cms.Server.Models.Blogs;

namespace Venus.Presentation.Web.Cms.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : CmsApiControllerBase
    {
        /*
            {
                "url": "/sdfssdfs",
                "title": "SDFSDF",
                "description": "DFSDF",
                "JsonData": {
                    "blogCategory": "SDFSDFSD",
                    "blogContent": "<p>SDFSDF</p>"
                }
            }
         */

        [HttpPost("create")]
        public async Task<IActionResult> CreateBlog(CreateBlogReq createBlogReq)
        {
            return Ok();
        }

    }
}
