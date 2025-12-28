using Microsoft.AspNetCore.Mvc.RazorPages;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.EntityDatas;
using Venus.Core.Application.Dtos.Systems.Pages;
using Venus.Core.Application.Dtos.Systems.Urls;
using Venus.Core.Application.Mappers;
using Venus.Core.Application.Mappers.Interfaces;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Mappings
{
    [Mapper]
    public partial class VenusUrlMapping
    {
        public partial ReadVenusUrlDto ToDto(VenusUrl venusUrl);
        public partial ReadVenusUrlSummaryDto ToSummaryDto(VenusUrl venusUrl);

    }
}
