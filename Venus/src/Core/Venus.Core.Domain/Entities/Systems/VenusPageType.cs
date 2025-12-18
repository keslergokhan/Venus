using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Domain.Entities.Base;

namespace Venus.Core.Domain.Entities.Systems
{
    public partial class VenusPageType : VenusEntityBase
    {
        public string InterfaceClassType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public partial class VenusPageType
    {
        public VenusPageAbout PageAbout { get; set; }
        public ICollection<VenusUrl> Urls { get; set; }
    }
}
