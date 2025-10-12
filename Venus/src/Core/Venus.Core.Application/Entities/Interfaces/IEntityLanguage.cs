using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Entities.Systems;

namespace Venus.Core.Application.Entities.Interfaces
{
    public interface IEntityLanguage
    {
        public Guid LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
