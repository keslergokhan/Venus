using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Domain.Entities.Base;

namespace Venus.Core.Domain.Entities.Systems
{
    public class VenusLanguage : VenusEntityBase
    {
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string Culture { get; set; }
        public byte Sort { get; set; }
        public string Currency { get; set; }

    }
}
