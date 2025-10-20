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
using Venus.Core.Application.Exceptions.Systems;
using Venus.Core.Application.Features.Systems.Urls.Queries;
using Venus.Core.Application.HttpRequests.Interfaces;
using Venus.Core.Application.Results.Interfaces;
using Venus.Presentation.Client.Core.PageTypeServices.Interfaces;
using static Venus.Core.Application.HttpRequests.VenusHttpContext;

namespace Venus.Presentation.Client.Core.DynamicRoutes
{
    public class VenusDynamicRouteValueTransformer : DynamicRouteValueTransformer
    {
        private readonly IMediator _m;
        private readonly IVenusHttpContext _venusContext;
        public required IServiceProvider _serviceProvider;
        public VenusDynamicRouteValueTransformer(IMediator m, IVenusHttpContext venusContext, IServiceProvider serviceProvider)
        {
            _m = m;
            _venusContext = venusContext;
            _serviceProvider = serviceProvider;
        }

        public override async ValueTask<RouteValueDictionary> TransformAsync(HttpContext context, RouteValueDictionary values)
        
        {
            string Path = context.Request.Path;
            string Schema = context.Request.Scheme;
            string FullPath = $"{context.Request.Scheme}://{context.Request.Host}{Path}";
            string BaseUrl = $"{context.Request.Scheme}://{context.Request.Host}";
            string Host = context.Request.Host.Value;

            IResultDataControl<List<ReadVenusUrlDto>> urlResult = await this._m.Send(new VenusGetUrlByFullPathQuery()
            {
                FullPath = Path
            });

            if (!urlResult.IsSuccess || urlResult.Data.Count == 0)
                throw new VenusNotFoundUrlException(FullPath);

            ReadVenusUrlDto url = urlResult.Data.FirstOrDefault();
            ReadVenusLanguageDto language = url.Language;
            ReadVenusPageDto page = url.Pages.FirstOrDefault();
            ReadVenusPageAboutDto pageAbout = page.PageAbout;
            ReadVenusPageTypeDto pageType = url.PageType;

            if (language == null)
                throw new VenusNotFoundLanguageException();

            if (page == null)
                throw new VenusNotFoundPageException(FullPath);

            if (pageAbout==null)
                throw new VenusNotFoundPageAboutException(page.Id,page.Name);

            if (pageType == null)
                throw new VenusNotFoundPageTypeException();

            this._venusContext.Url = new VenusHttpUrl(url.Id,FullPath,Schema,Host,Path,BaseUrl,url.ParentUrlId,url.IsEntity);
            this._venusContext.Language = new VenusHttpLanguage(language.Name,language.CountryCode,language.Culture,language.Currency,language.Id);
            this._venusContext.Page = new VenusHttpPage(page.Id,page.Name,page.Description,page.PageAbout.Controller,page.PageAbout.Action);

            Type pageTypeServiceType = Type.GetType(pageType.InterfaceClassType);

            if (pageTypeServiceType == null)
                throw new VenusNotFoundPageTypeServiceException(pageType.InterfaceClassType);

            IVenusPageTypeService pageTypeService = (IVenusPageTypeService)context.RequestServices.GetService(pageTypeServiceType);

            await pageTypeService.ExecuteAsync(this._venusContext,context);

            values["controller"] = this._venusContext.Page.Controller.Replace("Controller","");
            values["action"] = this._venusContext.Page.Action;

            return values;
        }
    }
}
