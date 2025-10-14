using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Domain.Entities.Base;
using Venus.Core.Domain.Entities.Interfaces;

namespace Venus.Core.Domain.Entities.Systems
{
    public class VenusEntityDataUrl:VenusEntityBase,IVenusUrlEntity
    {
        public Guid UrlId { get; set; }
        public VenusUrl Url { get; set; }
        public string EntityName {  get; set; }
        public string EntityClassType { get; set; }

    }
}
