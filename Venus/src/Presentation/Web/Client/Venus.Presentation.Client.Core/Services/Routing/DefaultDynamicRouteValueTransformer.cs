using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Venus.Core.Application.Features.Systems.Urls.Queries;

namespace Venus.Presentation.Client.Core.Services.Routing
{
    public class DefaultDynamicRouteValueTransformer : DynamicRouteValueTransformer
    {
        private readonly IMediator _m;

        public DefaultDynamicRouteValueTransformer(IMediator m)
        {
            _m = m;
        }

        public override async ValueTask<RouteValueDictionary> TransformAsync(HttpContext httpContext, RouteValueDictionary values)
        {
            var url = await _m.Send(new VenusGetUrlByFullPathQuery()
            {
                FullPath = "/hakkimizda"
            });
            string sss = "ffff";
            throw new NotImplementedException();
        }
    }
}
