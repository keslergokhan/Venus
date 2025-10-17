using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Venus.Presentation.Client.Core.DynamicRoutes;

namespace Venus.Presentation.Client.Core.Extensions
{
    public static class VenusEndpointRouteBuilderExtension
    {
        public static void VenusDynamicRoute(this IEndpointRouteBuilder routeBuilder)
        {
            routeBuilder.MapDynamicControllerRoute<VenusDynamicRouteValueTransformer>("{**slug}");
        } 
    }
}
