using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Domain.Entities.Base;
using Venus.Core.Domain.Entities.Interfaces;

namespace Venus.Core.Domain.Entities.Systems
{
    public partial class VenusLanguageResourceValue : VenusEntityBase, IVenusLanguageEntity
    {
        
        public string Value { get; set; }
        public Guid LanguageId { get; set; }
        public VenusLanguage Language { get; set; }
    }

    public partial class VenusLanguageResourceValue
    {
        public Guid ResourceKeyId { get; set; }
        public VenusLanguageResourceKey ResourceKey { get; set; }
    }   
}
