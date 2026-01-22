using Venus.Core.Application.Dtos.Base;
using Venus.Core.Application.Dtos.Interfaces;
using Venus.Core.Application.Dtos.Systems.Languages;
using Venus.Core.Application.Dtos.Systems.Pages;

namespace Venus.Core.Application.Dtos.Systems.Urls
{
    public class ReadVenusUrlSummaryDto : ReadVenusDtoBase
    {
        public string Path { get; set; }
        public string FullPath { get; set; }
        public short UrlType { get; set; }
        public Guid? ParentUrlId { get; set; }
        public Guid LanguageId { get; set; }
        public Guid PageTypeId { get; set; }
        public ReadVenusPageTypeDto PageType { get; set; }


    }
    public class ReadVenusUrlDto : ReadVenusUrlSummaryDto, IVenusEntityLanguageDto
    {
        public ReadVenusUrlSummaryDto ParentUrl { get; set; }
        public ReadVenusLanguageDto Language { get; set; }
        public List<ReadVenusUrlSummaryDto> SubUrls { get; set; }
        
        public List<ReadVenusPageSummaryDto> Pages { get; set; }
    }
}
