using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Urls;
using Venus.Core.Application.Enums.Systems;
using Venus.Core.Application.Exceptions.Systems;
using Venus.Core.Application.Features.Systems.Urls.Queries;
using Venus.Core.Application.HttpRequests.Interfaces;
using Venus.Core.Application.Results.Interfaces;
using Venus.Presentation.Client.Core.RequestHandler.Interfaces;
using static Venus.Core.Application.HttpRequests.VenusHttpContext;

namespace Venus.Presentation.Client.Core.RouterHandler
{
    public class RouterUrlHandler : RouterHandlerBase
    {
        public override async Task<IVenusHttpContext> HandleAsync(HttpContext httpContext,object request = null)
        {
            base.ServiceRegistration(httpContext);
            string Path = httpContext.Request.Path;
            string Schema = httpContext.Request.Scheme;
            string FullPath = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}{Path}";
            string BaseUrl = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}";
            string Host = httpContext.Request.Host.Value;

            IResultDataControl<List<ReadVenusUrlDto>> urlResult = await base.Mediator.Send(new VenusGetUrlByFullPathQuery()
            {
                FullPath = Path
            });

            if (!urlResult.IsSuccess)
                throw urlResult.Exception;

            var urlData = urlResult.Data.Where(x => x.UrlType != (short)UrlTypeEnum.Detail).ToList();

            ReadVenusUrlDto url = urlResult.Data.FirstOrDefault();

            if (url.Language == null)
                throw new VenusNotFoundLanguageException();

            this.VenusContext.Url = new VenusHttpUrl(FullPath, Schema, Host, Path, BaseUrl, url);
            this.VenusContext.Language = new VenusHttpLanguage(url.Language);

            return await base.HandleAsync(httpContext);
        }
    }
}
