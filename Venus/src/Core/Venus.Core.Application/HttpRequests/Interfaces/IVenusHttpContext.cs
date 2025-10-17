using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Venus.Core.Application.HttpRequests.VenusHttpContext;

namespace Venus.Core.Application.HttpRequests.Interfaces
{
    public interface IVenusHttpContext
    {
        public VenusHttpLanguage Language { get; set; }
        public VenusHttpUrl Url { get; set; }
        public VenusHttpPage Page { get; set; }
    }
}
