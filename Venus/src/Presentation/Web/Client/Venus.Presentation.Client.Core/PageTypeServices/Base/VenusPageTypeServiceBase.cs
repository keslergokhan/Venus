using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.HttpRequests;
using Venus.Core.Application.HttpRequests.Interfaces;
using Venus.Presentation.Client.Core.PageTypeServices.Interfaces;

namespace Venus.Presentation.Client.Core.PageTypeServices.Base
{
    public abstract class VenusPageTypeServiceBase : IVenusPageTypeService
    {

        public virtual async Task ExecuteAsync(IVenusHttpContext venusHttpContext,HttpContext httpContext)
        {

        }
    }
}
