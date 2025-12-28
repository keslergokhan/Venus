using Venus.Core.Application.Dtos.Base;
using Venus.Core.Application.Dtos.Interfaces;
using Venus.Core.Application.Dtos.Systems.Languages;
using Venus.Core.Application.Dtos.Systems.Urls;

namespace Venus.Core.Application.Dtos.Systems.Pages
{
    public class ReadVenusPageSummaryDto : ReadVenusDtoBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid UrlId { get; set; }
        public Guid LanguageId { get; set; }
        public Guid PageAboutId { get; set; }
        public Guid? ParentPageId { get; set; }
        public ReadVenusPageAboutDto PageAbout { get; set; } = new ReadVenusPageAboutDto();
        public ReadVenusUrlSummaryDto Url { get; set; } = new ReadVenusUrlSummaryDto();
    }
    public class ReadVenusPageDto : ReadVenusPageSummaryDto, IVenusUrlEntityDto,IVenusEntityLanguageDto
    {
        public ReadVenusLanguageDto Language { get; set; } = new ReadVenusLanguageDto();
        public ReadVenusPageSummaryDto ParentPage { get; set; } = new ReadVenusPageSummaryDto();
        public List<ReadVenusPageSummaryDto> SubPages { get; set; } = new List<ReadVenusPageSummaryDto>();
    }
}
