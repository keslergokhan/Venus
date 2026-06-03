using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Base;
using Venus.Core.Application.Dtos.Interfaces;
using Venus.Core.Application.Dtos.Systems.Languages;

namespace Venus.Core.Application.Dtos.Systems.Widget
{
    public class ReadVenusWidgetDataDto : ReadVenusDtoBase, IVenusEntityLanguageDto
    {
        public string Data { get; set; }
        public Guid LanguageId { get; set; }
        public ReadVenusLanguageDto Language { get; set; }

        public Guid WidgetId { get; set; }
        public ReadVenusWidgetDto Widget { get; set; }
    }
}
