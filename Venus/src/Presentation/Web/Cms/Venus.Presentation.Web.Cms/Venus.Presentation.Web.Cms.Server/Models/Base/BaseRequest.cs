using System.Text.Json.Serialization;
using Venus.Presentation.Web.Cms.Server.Extensions;

namespace Venus.Presentation.Web.Cms.Server.Models.Base
{
    public abstract class BaseRequest
    {
        public Guid? LanguageId { get; set; }
    }
}
