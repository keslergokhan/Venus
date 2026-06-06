using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Base;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Dtos.Systems.PageZone
{
    public class ReadVenusPageZoneDto : ReadVenusDtoBase
    {
        public string Key { get; set; }
        public Guid PageId { get; set; }
        public List<ReadVenusPageZoneWidgetDto> ZoneWidgets { get; set; }
    }
}
