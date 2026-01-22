using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Domain.Entities.Base;
using Venus.Core.Domain.Entities.Interfaces;

namespace Venus.Core.Domain.Entities.Systems
{
    public partial class VenusPageAbout : VenusEntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
    public partial class VenusPageAbout
    {
        public Guid PageTypeId { get; set; }

        public VenusEntityPage? EntityPage { get; set; }
        public Guid? EntityPageId { get; set; }
    }
}
