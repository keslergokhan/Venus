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

        private ReadVenusPageDto MapParentPage(VenusPage page)
        {
            if (page.ParentPage == null)
                return null;

            return ToDto(page.ParentPage);
        }

        private ReadVenusUrlDto MapUrl(VenusPage page)
        {
            return new ReadVenusUrlDto()
            {
                LanguageId = page.Url.LanguageId,
                Id = page.Url.Id,
                Path = page. Url.Path,
                PageTypeId = page.Url.PageTypeId,
                FullPath = page.Url.FullPath,
            };
        }

        private List<ReadVenusPageDto> MapSubPages(VenusPage page)
        {
            if (page.SubPages == null)
            {
                return null;
            }

            return page.SubPages.Select(x => new ReadVenusPageDto()
            {
                Url = MapUrl(x),
                Description = x.Description,
                LanguageId = x.LanguageId,  
                Id = x.Id,
                Name = x.Name,  
            }).ToList();
        }
    }
}
