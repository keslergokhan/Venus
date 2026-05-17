using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Domain.Entities.Base;

namespace Venus.Core.Domain.Entities.Systems
{
    public class VenusConfigurationSetting : VenusEntityBase
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public bool UpdatePermission { get; set; }
        public bool Hidden { get; set; }
    }
}
