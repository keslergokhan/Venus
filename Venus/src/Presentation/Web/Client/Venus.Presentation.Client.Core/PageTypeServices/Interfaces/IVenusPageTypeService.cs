using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.HttpRequests;
using Venus.Core.Application.HttpRequests.Interfaces;

namespace Venus.Presentation.Client.Core.PageTypeServices.Interfaces
{
    /// <summary>
    /// PageType sistemi için temel interface.
    /// </summary>
    /// <remarks>
    /// <see cref="Venus.Presentation.Client.Core.RouterHandler.RouterPageTypeServiceHandler"/> handler içinde 
    /// <see cref="Venus.Core.Domain.Entities.Systems.VenusPageType"/> tablosunda tanımlı servisin
    /// çalıştırılabilmesi için <see cref="IVenusPageTypeService"/> implemente etmesi gerekir.
    /// </remarks>
    public interface IVenusPageTypeService
    {
        public Task ExecuteAsync(IVenusHttpContext venusHttpContext, HttpContext httpContext);
    }
}
