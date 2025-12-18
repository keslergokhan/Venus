using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Pages;
using Venus.Core.Application.Dtos.Systems.Urls;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Mappings
{
    [Mapper]
    public partial class VenusPageMapper
    {
        [MapPropertyFromSource(nameof(ReadVenusPageDto.Url), Use = nameof(VenusPageMapper.MapUrl))]
        [MapPropertyFromSource(nameof(ReadVenusPageDto.SubPages), Use = nameof(VenusPageMapper.MapSubPages))]
        [MapPropertyFromSource(nameof(ReadVenusPageDto.ParentPage), Use = nameof(VenusPageMapper.MapParentPage))]
        public partial ReadVenusPageDto ToDto(VenusPage venusPage);

        private ReadVenusPageDto MapParentPage(VenusPage venusPage)
        {
            if (venusPage.ParentPage == null)
                return null;

            return ToDto(venusPage.ParentPage);
        }

        private ReadVenusUrlDto MapUrl(VenusUrl Url)
        {
            return new ReadVenusUrlDto()
            {
                LanguageId = Url.LanguageId,
                Id = Url.Id,
                Path = Url.Path,
                PageTypeId = Url.PageTypeId,
            };
        }

        private List<ReadVenusPageDto> MapSubPages(VenusPage venusPages)
        {
            if (venusPages.SubPages == null)
            {
                return null;
            }

            return venusPages.SubPages.Select(x => ToDto(x)).ToList();
        }
    }
}
