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
    public class RouterUrlHandler : RouterHandlerBase
    {
        public override async Task<IVenusHttpContext> HandleAsync(HttpContext httpContext)
        {
            return await base.HandleAsync(httpContext);
        }
    }
}
