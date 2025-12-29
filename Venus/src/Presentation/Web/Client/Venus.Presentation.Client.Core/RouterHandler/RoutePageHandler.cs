using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Languages;
using Venus.Core.Application.Dtos.Systems.Pages;
using Venus.Core.Application.Dtos.Systems.Urls;
using Venus.Core.Application.Exceptions.Systems;
using Venus.Core.Application.Features.Systems.Pages.Queries;
using Venus.Core.Application.HttpRequests.Interfaces;
using Venus.Core.Application.Results.Interfaces;
using Venus.Presentation.Client.Core.RequestHandler.Interfaces;
using static Venus.Core.Application.HttpRequests.VenusHttpContext;

namespace Venus.Presentation.Client.Core.RouterHandler
{
    public class RoutePageHandler : RouterHandlerBase
    {
        public override async Task<IVenusHttpContext> HandleAsync(HttpContext context,object request = null)
        {
            base.ServiceRegistration(context);
            IResultDataControl<ReadVenusPageDto> result = await base.Mediator.Send(new VenusGetPageByUrlIdAndUrlTypeQuery()
            {
                ParentUrlId = base.VenusContext.Url.ParentId,
                UrlId = base.VenusContext.Url.Id,
                UrlType = base.VenusContext.Url.UrlType
            });

            if (!result.IsSuccess)
            {
                throw result.Exception;
            }

            ReadVenusPageDto page = result.Data;

            if (page == null)
                throw new VenusNotFoundPageException();

            if (page.PageAbout == null)
                throw new VenusNotFoundPageAboutException(page.Id, page.Name);

            if (page.PageAbout.PageType == null)
                throw new VenusNotFoundPageTypeException();

            ReadVenusPageTypeDto pageType = page.PageAbout.PageType;
            base.VenusContext.Page = new VenusHttpPage(page);

            return await base.HandleAsync(context, pageType);
        }
    }
}
