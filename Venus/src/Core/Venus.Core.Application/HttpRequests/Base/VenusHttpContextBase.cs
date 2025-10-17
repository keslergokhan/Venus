using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.HttpRequests.Interfaces;
using static Venus.Core.Application.HttpRequests.VenusHttpContext;

namespace Venus.Core.Application.HttpRequests.Base
{
    public class VenusHttpContextBase : IVenusHttpContext
    {
        public VenusHttpLanguage Language { get; set; }
        public VenusHttpUrl Url { get; set; }
        public VenusHttpPage Page { get; set; }
        
    }
}
