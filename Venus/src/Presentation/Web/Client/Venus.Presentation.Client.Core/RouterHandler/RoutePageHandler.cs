using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Languages;
using Venus.Core.Application.Dtos.Systems.Pages;
using Venus.Core.Application.Dtos.Systems.Urls;
using Venus.Core.Application.Enums.Systems;
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
        public override async Task<IVenusHttpContext> HandleAsync(HttpContext httpContext, object request = null)
        {
            base.ServiceRegistration(httpContext);

            string Path = httpContext.Request.Path;
            string Schema = httpContext.Request.Scheme;
            string FullPath = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}{Path}";
            string BaseUrl = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}";
            string Host = httpContext.Request.Host.Value;

            List<ReadVenusUrlDto> req = request as List<ReadVenusUrlDto>;

            if (req.Any(x=> (x.Pages == null || !x.Pages.Any()) && x.ParentUrl == null))
                throw new VenusNotFoundPageException();

            if (req.Any(x => x.Pages.Any(i => i.PageAbout == null)))
                throw new VenusNotFoundPageAboutException();

            if (req.Any(x => x.Pages.Any(i => i.PageAbout.PageType == null)))
                throw new VenusNotFoundPageTypeException();


            
            if (req.Count > 1)
            {
                throw new VenusDoubleUrlException();
            }
          
            ReadVenusUrlDto currentUrl = req.First();

            if (currentUrl.Pages.Count() > 1)
            {
                throw new VenusDoubleUrlException();
            }

            bool isEntity = currentUrl.Pages.Any(x => x.PageAbout.PageEntity != null);

            ReadVenusPageSummaryDto currentPage = currentUrl.Pages.FirstOrDefault();


            if (currentPage == null)
            {
                currentPage = currentUrl.ParentUrl?.Pages.FirstOrDefault();
            }

            this.VenusContext.Url =
                new VenusHttpUrl(
                    currentUrl.Id
                    ,Path
                    ,FullPath
                    ,BaseUrl
                    ,Schema
                    ,Host
                    ,""
                    ,currentUrl.ParentUrlId
                    ,isEntity);

            this.VenusContext.Language = 
                new VenusHttpLanguage(
                    currentUrl.LanguageId
                    ,currentUrl.Language.Name
                    ,currentUrl.Language.CountryCode
                    ,currentUrl.Language.Culture
                    ,currentUrl.Language.Currency);

            this.VenusContext.Page = new VenusHttpPage(
                currentPage.Id
                ,currentPage.Name
                ,currentPage.Description
                ,currentPage.PageAbout.Controller
                ,currentPage.PageAbout.Action
                ,currentPage.PageAbout?.PageEntity?.EntityName,
                Enum.Parse<PageTypeEnum>(currentPage.PageAbout.PageType.Title),
                currentPage.PageAbout?.PageEntity?.EntityClassType);

            return await base.HandleAsync(httpContext, currentPage.PageAbout.PageType);
        }
    }
}
