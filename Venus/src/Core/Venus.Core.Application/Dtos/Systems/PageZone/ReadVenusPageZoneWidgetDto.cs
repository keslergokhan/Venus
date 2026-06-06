using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Base;
using Venus.Core.Application.Dtos.Systems.Languages;
using Venus.Core.Application.Dtos.Systems.Widget;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Dtos.Systems.PageZone
{
    public class ReadVenusPageZoneWidgetDto : ReadVenusDtoBase
    {
        public Guid ZoneId { get; set; }
        public Guid WidgetId { get; set; }
        public ReadVenusWidgetDto Widget { get; set; }
        public string WidgetData { get; set; }
        public Guid LanguageId { get; set; }
        public ReadVenusLanguageDto Language { get; set; }
    }
}
