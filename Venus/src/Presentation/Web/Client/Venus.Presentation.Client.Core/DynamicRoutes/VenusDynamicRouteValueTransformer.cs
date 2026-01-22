using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Venus.Core.Application.HttpRequests.Interfaces;
using Venus.Presentation.Client.Core.RequestHandler.Interfaces;
using Venus.Presentation.Client.Core.RouterHandler;

namespace Venus.Presentation.Client.Core.DynamicRoutes
{
    public class VenusDynamicRouteValueTransformer : DynamicRouteValueTransformer
    {
        private readonly IMediator _m;
        private readonly IVenusHttpContext _venusContext;
        public VenusDynamicRouteValueTransformer(IMediator m, IVenusHttpContext venusContext)
        {
            _m = m;
            _venusContext = venusContext;
        }
        public override async ValueTask<RouteValueDictionary> TransformAsync(HttpContext context, RouteValueDictionary values)
        {
            RouterHandlerBase urlHandler = new RouterUrlHandler();

            urlHandler // Request üzerinde url parçalandı ve db kaydına erişildi
                .Next(new RoutePageHandler()) //Url bağlı sayfa ve sayfanın ayarlarına ulaşıldı.
                .Next(new RouterPageTypeServiceHandler()); //sayfa tipi servisi çalıştırıldı.   

            await urlHandler.HandleAsync(context);
            

            values["controller"] = this._venusContext.Page.Controller.Replace("Controller","");
            values["action"] = this._venusContext.Page.Action;

            return values;
        }
    }
}
