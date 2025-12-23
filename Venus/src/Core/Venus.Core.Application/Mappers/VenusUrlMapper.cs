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

        [MapPropertyFromSource(nameof(ReadVenusUrlDto.ParentUrl), Use = nameof(VenusUrlMapping.MapParentUrl))]
        [MapPropertyFromSource(nameof(ReadVenusUrlDto.SubUrls), Use = nameof(VenusUrlMapping.MapSubUrls))]
        [MapPropertyFromSource(nameof(ReadVenusUrlDto.Pages), Use = nameof(VenusUrlMapping.MapPages))]
        public partial ReadVenusUrlDto ToDto(VenusUrl venusUrl);


        private ReadVenusUrlDto MapParentUrl(VenusUrl url)
        {
            if (url.ParentUrl == null)
                return null;

            return ToDto(url.ParentUrl);
        }

        private List<ReadVenusUrlDto> MapSubUrls(VenusUrl url)
        {
            if (url.SubUrls == null)
                return null;

            return url.SubUrls.Select(x=>ToDto(x)).ToList();
        }

        public List<ReadVenusPageDto> MapPages(VenusUrl url)
        {
            if (url.Pages == null)
                return null;

            return url.Pages.Select(x => _pageMapping.ToDto(x)).ToList();
        }


    }
}
