using Venus.Core.Application.Dtos.Base;

namespace Venus.Core.Application.Dtos.Systems.Languages
{
    public class ReadVenusLanguageDto : ReadVenusDtoBase
    {
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string Culture { get; set; }
        public byte Sort { get; set; }
        public string Currency { get; set; }
    }
}
