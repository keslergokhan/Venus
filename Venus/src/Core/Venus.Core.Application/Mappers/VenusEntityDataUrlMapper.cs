using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.EntityDatas;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Mappers
{
    [Mapper]
    public partial class VenusEntityDataUrlMapper
    {
        public partial ReadVenusEntityDataUrlDto ToDto(VenusEntityDataUrl venusEntityDataUrl);
    }
}
