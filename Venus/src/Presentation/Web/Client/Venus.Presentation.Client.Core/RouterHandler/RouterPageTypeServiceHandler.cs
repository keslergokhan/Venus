using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Pages;
using Venus.Core.Application.Dtos.Systems.Urls;
using Venus.Core.Application.Exceptions.Systems;
using Venus.Core.Application.HttpRequests.Interfaces;
using Venus.Presentation.Client.Core.PageTypeServices.Interfaces;
using Venus.Presentation.Client.Core.RequestHandler.Interfaces;

namespace Venus.Presentation.Client.Core.RouterHandler
{
    /// <summary>
    /// <see cref="Venus.Core.Domain.Entities.Systems.VenusPageType"/> üzerinden sayfaya bağlı olan tip servisi çalıştırılır. 
    /// </summary>
    /// <remarks>
    ///     <para><see cref="Venus.Core.Application.Enums.Systems.PageTypeEnum"/> Belirli sayfa tipleri vardır, sayfanın tipine göre servis çalıştırılır.</para>
    ///     <list type="bullet">
    ///         <item>VenusDefaultPage</item>
    ///         <item>VenusEntityListPage</item>
    ///         <item>VenusEntityDetailPage</item>
    ///     </list>
    /// </remarks>
    public class RouterPageTypeServiceHandler : RouterHandlerBase
    {
        public override async Task<IVenusHttpContext> HandleAsync(HttpContext context, object reqeust)
        {
            base.ServiceRegistration(context);
            ReadVenusPageTypeDto pageTypeDto = (ReadVenusPageTypeDto)reqeust;
            Type pageTypeServiceType = Type.GetType(pageTypeDto.InterfaceClassType);

            if (pageTypeServiceType == null)
                throw new VenusNotFoundPageTypeServiceException(pageTypeDto.InterfaceClassType);

            IVenusPageTypeService pageTypeService = (IVenusPageTypeService)context.RequestServices.GetService(pageTypeServiceType);

            await pageTypeService.ExecuteAsync(base.VenusContext, context);

            return await base.HandleAsync(context);
        }
    }
}
