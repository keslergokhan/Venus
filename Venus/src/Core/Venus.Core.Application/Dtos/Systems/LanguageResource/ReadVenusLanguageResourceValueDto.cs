using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Base;
using Venus.Core.Application.Dtos.Systems.Languages;
using Venus.Core.Domain.Entities.Interfaces;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Dtos.Systems.LanguageResource
{
    public class ReadVenusLanguageResourceValueDto : ReadVenusDtoBase
    {
        public string Value { get; set; }
        public Guid LanguageId { get; set; }
        public ReadVenusLanguageDto Language { get; set; }
        
    }
}
