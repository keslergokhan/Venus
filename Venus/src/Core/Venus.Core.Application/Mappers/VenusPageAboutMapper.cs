using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.EntityDatas;
using Venus.Core.Application.Dtos.Systems.Pages;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Mappers
{
    [Mapper]
    public partial class VenusPageAboutMapper
    {
        public partial ReadVenusPageAboutDto ToDto(VenusPageAbout venusPage);

        public ReadVenusPageTypeDto MapPageType(VenusPageType venusPageType)
        {
            if (venusPageType == null)
            {
                return null;
            }

            return new ReadVenusPageTypeDto()
            {
                Title = venusPageType.Title,
                Description = venusPageType.Description,
                Id = venusPageType.Id
            };
        }

        public ReadVenusEntityDataUrlDto MapEntityDataUrl(VenusEntityDataUrl venusEntityDataUrl)
        {
            if (venusEntityDataUrl==null)
            {
                return null;
            }

            return new ReadVenusEntityDataUrlDto()
            {
                EntityClassType = venusEntityDataUrl.EntityClassType,
                EntityName = venusEntityDataUrl.EntityName,
                Id = venusEntityDataUrl.Id
            };
        }
    }
}
