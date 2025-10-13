using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Domain.Entities.Base;
using Venus.Core.Domain.Entities.Interfaces;

namespace Venus.Core.Domain.Entities.Systems
{
    public class Localization : EntityBase, IEntityLanguage
    {
        public string Key { get; set; } 
        public string DefaultValue { get; set; }    
        public string Value { get; set; }
        public Guid LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
