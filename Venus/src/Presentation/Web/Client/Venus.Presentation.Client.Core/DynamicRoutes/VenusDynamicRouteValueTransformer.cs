using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Venus.Core.Application.Dtos.Systems.Languages;
using Venus.Core.Application.Dtos.Systems.Pages;
using Venus.Core.Application.Dtos.Systems.Urls;
using Venus.Core.Application.Enums.Systems;
using Venus.Core.Application.Exceptions.Systems;
using Venus.Core.Application.Features.Systems.Urls.Queries;
using Venus.Core.Application.HttpRequests.Interfaces;
using Venus.Core.Application.Results.Interfaces;
using Venus.Presentation.Client.Core.PageTypeServices.Interfaces;
using Venus.Presentation.Client.Core.RequestHandler.Interfaces;
using Venus.Presentation.Client.Core.RouterHandler;
using static Venus.Core.Application.HttpRequests.VenusHttpContext;

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
            urlHandler.Next(new RoutePageHandler(context)).Next(new RouterPageTypeServiceHandler());

            await urlHandler.HandleAsync(context);


            //string Path = context.Request.Path;
            //string Schema = context.Request.Scheme;
            //string FullPath = $"{context.Request.Scheme}://{context.Request.Host}{Path}";
            //string BaseUrl = $"{context.Request.Scheme}://{context.Request.Host}";
            //string Host = context.Request.Host.Value;

            //IResultDataControl<List<ReadVenusUrlDto>> urlResult = await this._m.Send(new VenusGetUrlByFullPathQuery()
            //{
            //    FullPath = Path
            //});

            //if (!urlResult.IsSuccess)
            //    throw urlResult.Exception;


            //var urlData = urlResult.Data.Where(x => x.UrlType != (short)UrlTypeEnum.Detail).ToList();

            //ReadVenusUrlDto url = urlResult.Data.FirstOrDefault();
            //ReadVenusLanguageDto language = url.Language;
            //ReadVenusPageDto page = url.Pages.FirstOrDefault();
            //ReadVenusPageAboutDto pageAbout = page.PageAbout;
            //ReadVenusPageTypeDto pageType = url.PageType;

            //if(language == null)
            //        throw new VenusNotFoundLanguageException();

            //if (page == null)
            //    throw new VenusNotFoundPageException(FullPath);

            //if (pageAbout == null)
            //    throw new VenusNotFoundPageAboutException(page.Id, page.Name);

            //if (pageType == null)
            //    throw new VenusNotFoundPageTypeException();


            //this._venusContext.Url = new VenusHttpUrl(FullPath,Schema,Host,Path,BaseUrl,url);
            //this._venusContext.Language = new VenusHttpLanguage(language);
            //this._venusContext.Page = new VenusHttpPage(page.Id,page.Name,page.Description,page.PageAbout.Controller,page.PageAbout.Action);

            

            values["controller"] = this._venusContext.Page.Controller.Replace("Controller","");
            values["action"] = this._venusContext.Page.Action;

            return values;
        }
    }
}
