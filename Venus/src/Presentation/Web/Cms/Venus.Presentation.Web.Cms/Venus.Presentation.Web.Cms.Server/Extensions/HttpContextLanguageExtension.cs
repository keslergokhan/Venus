using Venus.Core.Application.Exceptions.Systems;

namespace Venus.Presentation.Web.Cms.Server.Extensions
{
    public static class HttpContextLanguageExtension
    {
        public static Guid GetLanguageId(this HttpContext httpContext)
        {
            if (httpContext == null) throw new ArgumentNullException(nameof(httpContext));

            var httLanguage = httpContext.Request.Headers["LanguageId"].FirstOrDefault();
            if (Guid.TryParse(httLanguage, out Guid result))
            {
                return result;
            }

            throw new VenusNotFoundLanguageException();
        }
    }
}
