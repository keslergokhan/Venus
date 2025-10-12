using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Entities.Base;

namespace Venus.Core.Application.Entities.Systems
{
    public class Language : EntityBase
    {
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string Culture { get; set; }
        public byte Sort { get; set; }
        public string Currency { get; set; }

    }
}
