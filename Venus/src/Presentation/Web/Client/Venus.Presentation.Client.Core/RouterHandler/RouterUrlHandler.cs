using Microsoft.AspNetCore.Http;
using Venus.Core.Application.Dtos.Systems.Urls;
using Venus.Core.Application.Exceptions.Systems;
using Venus.Core.Application.Features.Systems.Queries;
using Venus.Core.Application.HttpRequests.Interfaces;
using Venus.Core.Application.Results.Interfaces;
using Venus.Presentation.Client.Core.RequestHandler.Interfaces;
using static Venus.Core.Application.HttpRequests.VenusHttpContext;

namespace Venus.Presentation.Client.Core.RouterHandler
{
    /// <summary>
    /// URL bilgisi tespit edilir.
    /// </summary>
    /// <remarks>
    /// <para><see cref="GetVenusUrlByFullPathQuery"/> ile sayfa yönlendirme kararı belirlenir.</para>
    /// </remarks>
    public class RouterUrlHandler : RouterHandlerBase
    {
        public override async Task<IVenusHttpContext> HandleAsync(HttpContext httpContext,object request = null)
        {
            base.ServiceRegistration(httpContext);
            string Path = httpContext.Request.Path;

            IResultDataControl<List<ReadVenusUrlDto>> urlResult = await base.Mediator.Send(new GetVenusUrlByFullPathQuery()
            {
                FullPath = Path
            });

            if (!urlResult.IsSuccess)
                throw urlResult.Exception;

            if (urlResult.Data.Count == 0)
            {
                throw new VenusNotFoundUrlSystemException(Path);
            }

            if (urlResult.Data.Any(x=>x.Language == null))
                throw new VenusNotFoundLanguageSystemException();
           
            return await base.HandleAsync(httpContext,urlResult.Data);
        }
    }
}
