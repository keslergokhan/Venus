using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Domain.Entities.Base;
using Venus.Core.Domain.Entities.Interfaces;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Domain.Entities
{
    public class Blog : VenusEntityBase, IVenusUrlEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid UrlId { get; set; }
        public VenusUrl Url { get; set; }
    }
}
