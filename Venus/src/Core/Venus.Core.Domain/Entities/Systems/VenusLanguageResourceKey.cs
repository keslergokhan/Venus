using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Domain.Entities.Base;

namespace Venus.Core.Domain.Entities.Systems
{
    public partial class VenusLanguageResourceKey : VenusEntityBase
    {
        public string Key { get; set; }
        public string DefaultValue { get; set; }
        public bool IsHtml { get; set; }

    }

    public partial class VenusLanguageResourceKey
    {
        public ICollection<VenusLanguageResourceValue> ResourceValue { get; set; }
    }
}
