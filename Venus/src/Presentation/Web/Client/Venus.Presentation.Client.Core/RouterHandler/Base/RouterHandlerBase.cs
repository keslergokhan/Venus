using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Urls;
using Venus.Core.Application.HttpRequests.Interfaces;

namespace Venus.Presentation.Client.Core.RequestHandler.Interfaces
{
    public abstract class RouterHandlerBase : IRouterHandler
    {
        private IRouterHandler _nextHandler;
        protected IMediator MediatR;
        protected IVenusHttpContext VenusContext;

       
        public virtual async Task<IVenusHttpContext> HandleAsync(HttpContext context)
        {
            if (this._nextHandler != null)
            {
                return await this._nextHandler.HandleAsync(context);
            }
            return this.VenusContext;
        }

        public IRouterHandler Next(IRouterHandler routerHandler)
        {
            this._nextHandler = routerHandler;
            return routerHandler;
        }
    }
}
