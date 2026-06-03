using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Domain.Entities.Base;
using Venus.Core.Domain.Entities.Interfaces;

namespace Venus.Core.Domain.Entities.Systems
{
    public class VenusWidgetData : VenusEntityBase, IVenusLanguageEntity
    {
        public string Data { get; set; }
        public Guid LanguageId { get; set; }
        public VenusLanguage Language { get; set; }

        public Guid WidgetId { get; set; }
        public VenusWidget Widget { get; set; }
    }
}
