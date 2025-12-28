using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.EntityDatas;
using Venus.Core.Application.Dtos.Systems.Pages;
using Venus.Core.Application.Dtos.Systems.Urls;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Mappings
{
    [Mapper]
    public partial class VenusPageMapper
    {
        public partial ReadVenusPageDto ToDto(VenusPage venusPage);
        public partial ReadVenusPageSummaryDto ToSummaryDto(VenusPage venusPage);

    }
}
