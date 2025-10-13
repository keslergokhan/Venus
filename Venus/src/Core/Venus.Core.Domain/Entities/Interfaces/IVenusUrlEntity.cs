using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Domain.Entities.Interfaces
{
    public interface IVenusUrlEntity
    {
        public Guid UrlId { get; set; }
        public VenusUrl Url { get; set; }
    }
}
