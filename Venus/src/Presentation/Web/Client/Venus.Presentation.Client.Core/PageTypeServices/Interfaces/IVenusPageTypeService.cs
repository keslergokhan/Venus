using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.HttpRequests;
using Venus.Core.Application.HttpRequests.Interfaces;

namespace Venus.Presentation.Client.Core.PageTypeServices.Interfaces
{
    public interface IVenusPageTypeService
    {
        public Task ExecuteAsync(IVenusHttpContext venusHttpContext);
    }
}
