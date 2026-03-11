using Venus.Presentation.Web.Cms.Server.Models.Base;

namespace Venus.Presentation.Web.Cms.Server.Models.PageManagers
{
    public class CreatePageReq : BaseRequest
    {
        public string UrlPath { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid PageAboutId { get; set; }
    }
}
