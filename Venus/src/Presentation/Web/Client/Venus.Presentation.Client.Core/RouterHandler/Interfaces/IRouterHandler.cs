using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Urls;
using Venus.Core.Application.HttpRequests.Interfaces;

namespace Venus.Presentation.Client.Core.RequestHandler.Interfaces
{
    public interface IRouterHandler
    {
        public IRouterHandler Next(IRouterHandler routerHandler);
        public Task<IVenusHttpContext> HandleAsync(HttpContext context);
    }
}
