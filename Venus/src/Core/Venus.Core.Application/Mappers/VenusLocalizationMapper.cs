using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Languages;
using Venus.Core.Application.Dtos.Systems.Localizations;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Mappers
{
    [Mapper]
    public partial class VenusLocalizationMapper
    {
        public partial ReadVenusLocalizationDto ToDto(VenusLocalization venusLocalization);

        public ReadVenusLanguageDto MapLanguage(VenusLanguage venusLanguage)
        {
            if (venusLanguage == null)
            {
                return null;
            }

            return new ReadVenusLanguageDto()
            {
                CountryCode = venusLanguage.CountryCode,
                Culture = venusLanguage.Culture,
                Currency = venusLanguage.Currency,
                Id = venusLanguage.Id,
                Name = venusLanguage.Name,
                Sort = venusLanguage.Sort
            };
        }
    }
}
