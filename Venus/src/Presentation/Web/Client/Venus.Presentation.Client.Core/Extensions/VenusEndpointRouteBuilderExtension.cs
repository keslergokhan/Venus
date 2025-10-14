using Venus.Presentation.Client.Core.Services.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Venus.Presentation.Client.Core.Extensions
{
    public static class VenusEndpointRouteBuilderExtension
    {
        public static void VenusDynamicRoute(this IEndpointRouteBuilder routeBuilder)
        {
            routeBuilder.MapDynamicControllerRoute<DefaultDynamicRouteValueTransformer>("{**slug}");
        } 
    }
}
