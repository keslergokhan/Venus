using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Base;
using Venus.Core.Application.Dtos.Interfaces;
using Venus.Core.Application.Dtos.Systems.Languages;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Dtos.Systems.Localizations
{
    public class ReadVenusLocalizationDto : ReadVenusDtoBase, IVenusEntityLanguageDto
    {
        public string Key { get; set; }
        public string DefaultValue { get; set; }
        public string Value { get; set; }
        public Guid LanguageId { get; set; }
        public ReadVenusLanguageDto Language { get; set; }
    }
}
