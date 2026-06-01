namespace Venus.Presentation.Web.Cms.Server.Models.Languages
{
    public class UpdateLanguageResourceValueReq
    {
        public Guid LanguageId { get; set; }
        public bool IsHtml { get; set; }
        public string LanguageResourceValue { get; set; }
        public Guid ResourceId { get; set; }
    }
}
