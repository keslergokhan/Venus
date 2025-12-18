using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.EntityDatas;
using Venus.Core.Application.Dtos.Systems.Pages;
using Venus.Core.Application.Dtos.Systems.Urls;
using Venus.Core.Application.Mappers.Interfaces;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Mappings
{
    [Mapper]
    public partial class VenusUrlMapping
    {
        private VenusPageMapper _pageMapping;

        public VenusUrlMapping(VenusPageMapper pageMapping)
        {
            _pageMapping = pageMapping;
        }

        [MapPropertyFromSource(nameof(ReadVenusUrlDto.Pages), Use = nameof(VenusUrlMapping.MapPages))]
        [MapPropertyFromSource(nameof(ReadVenusUrlDto.ParentUrl), Use = nameof(VenusUrlMapping.MapParentUrl))]
        [MapPropertyFromSource(nameof(ReadVenusUrlDto.SubUrls), Use = nameof(VenusUrlMapping.MapSubUrls))]
        public partial ReadVenusUrlDto ToDto(VenusUrl venusUrl);


        private List<ReadVenusPageDto> MapPages(VenusUrl ParentUrl)
        {
            return ParentUrl.Pages.Select(x => this._pageMapping.ToDto(x)).ToList();
        }

        private ReadVenusUrlDto MapParentUrl(VenusUrl ParentUrl)
        {
            if (ParentUrl.ParentUrl == null)
                return null;

            return ToDto(ParentUrl.ParentUrl);
        }

        private List<ReadVenusUrlDto> MapSubUrls(VenusUrl ParentUrl)
        {
            if (ParentUrl.SubUrls == null)
                return null;

            return ParentUrl.SubUrls.Select(x=>ToDto(x)).ToList();
        }

        


    }
}
