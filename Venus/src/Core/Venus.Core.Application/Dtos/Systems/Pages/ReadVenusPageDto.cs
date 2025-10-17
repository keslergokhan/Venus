using Venus.Core.Application.Dtos.Base;
using Venus.Core.Application.Dtos.Interfaces;
using Venus.Core.Application.Dtos.Systems.Languages;
using Venus.Core.Application.Dtos.Systems.Urls;
using Venus.Core.Domain.Entities.Interfaces;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Dtos.Systems.Pages
{
    public class ReadVenusPageDto : ReadVenusDtoBase, IVenusUrlEntityDto,IVenusEntityLanguageDto
    {
        public string Name { get; set; }
        public ReadVenusUrlDto Url { get; set; }
        public string Description { get; set; } 
        public Guid UrlId { get; set; }
        public Guid LanguageId { get; set; }
        public ReadVenusLanguageDto Language { get; set; }
        public Guid PageAboutId { get; set; }
        public ReadVenusPageAboutDto PageAbout { get; set; }
        public Guid? ParentPageId { get; set; }
        public ReadVenusPageDto ParentPage { get; set; }

        public List<ReadVenusPageDto> SubPages { get; set; }
    }
}
