using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Urls;
using Venus.Core.Application.HttpRequests.Interfaces;
using Venus.Presentation.Client.Core.RequestHandler.Interfaces;

namespace Venus.Presentation.Client.Core.RouterHandler
{
    public class RoutePageHandler : RouterHandlerBase
    {

        public override async Task<IVenusHttpContext> HandleAsync(HttpContext context)
        {
            return await base.HandleAsync(context);
        }
    }
}
