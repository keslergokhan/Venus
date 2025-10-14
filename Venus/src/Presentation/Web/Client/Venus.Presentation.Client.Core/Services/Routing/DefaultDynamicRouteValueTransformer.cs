using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;

namespace Venus.Presentation.Client.Core.Services.Routing
{
    public class DefaultDynamicRouteValueTransformer : DynamicRouteValueTransformer
    {
        public override async ValueTask<RouteValueDictionary> TransformAsync(HttpContext httpContext, RouteValueDictionary values)
        {
            string sss = "ffff";
            throw new NotImplementedException();
        }
    }
}
