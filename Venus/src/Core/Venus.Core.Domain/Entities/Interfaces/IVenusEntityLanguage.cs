using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Domain.Entities.Interfaces
{
    public interface IVenusEntityLanguage: IVenusEntity
    {
        public Guid LanguageId { get; set; }
        public VenusLanguage Language { get; set; }
    }
}
