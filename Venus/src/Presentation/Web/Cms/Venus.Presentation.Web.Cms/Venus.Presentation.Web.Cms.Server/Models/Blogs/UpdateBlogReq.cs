using Venus.Presentation.Web.Cms.Server.Models.Base;

namespace Venus.Presentation.Web.Cms.Server.Models.Blogs
{
    public class UpdateBlogReq : BaseRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string DynamicProperties { get; set; }
        public string UrlPath { get; set; }
    }
}
