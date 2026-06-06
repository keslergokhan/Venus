using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Domain.Entities.Base;

namespace Venus.Core.Domain.Entities.Systems
{
    public partial class VenusPageZone : VenusEntityBase
    {
        public string Key { get; set; }
    }

    public partial class VenusPageZone
    {
        public Guid PageId { get; set; }
        public ICollection<VenusPageZoneWidget> ZoneWidgets { get; set; }
    }


}
