using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Pages;
using Venus.Core.Application.Dtos.Systems.Urls;
using Venus.Core.Application.HttpRequests.Interfaces;

namespace Venus.Presentation.Client.Core.RequestHandler.Interfaces
{
    public abstract class RouterHandlerBase : IRouterHandler
    {
        private IRouterHandler _nextHandler;
        protected IVenusHttpContext VenusContext;
        protected IMediator Mediator;
        protected ReadVenusPageTypeDto CurrentPageTypeService;

        public virtual void ServiceRegistration(HttpContext context)
        {
            if (this.Mediator == null)
            {
                this.Mediator = context.RequestServices.GetRequiredService<IMediator>();
            }

            if (this.VenusContext == null)
            {
                this.VenusContext = context.RequestServices.GetRequiredService<IVenusHttpContext>();
            }
        }
        public virtual async Task<IVenusHttpContext> HandleAsync(HttpContext context)
        {
            ServiceRegistration(context);
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
