using Venus.Core.Application.Dtos.Base;
using Venus.Core.Application.Dtos.Interfaces;
using Venus.Core.Application.Dtos.Systems.LanguageResource;
using Venus.Core.Application.Dtos.Systems.Languages;

namespace Venus.Core.Application.Dtos.Systems.Localizations
{
    public class ReadVenusLanguageResourceKeyDto : ReadVenusDtoBase
    {
        public string Key { get; set; }
        public string DefaultValue { get; set; }
        public bool IsHtml { get; set; }
        public List<ReadVenusLanguageResourceValueDto> ResourceValue { get; set; }

    }
}
