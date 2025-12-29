using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.HttpRequests.Interfaces;
using Venus.Presentation.Client.Core.PageTypeServices.Base;
using Venus.Presentation.Client.Core.PageTypeServices.Interfaces;

namespace Venus.Presentation.Client.Core.PageTypeServices
{
    public class VenusEntityDetailPageTypeService : VenusPageTypeServiceBase, IVenusEntityDetailPageTypeService
    {
        public override async Task ExecuteAsync(IVenusHttpContext venusHttpContext, HttpContext httpContext)
        {
            base.ExecuteAsync(venusHttpContext, httpContext);

        }
    }
}
