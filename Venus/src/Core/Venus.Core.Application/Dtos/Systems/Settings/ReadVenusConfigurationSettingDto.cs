using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Base;
using Venus.Core.Application.Dtos.Interfaces;

namespace Venus.Core.Application.Dtos.Systems.Settings
{
    public class ReadVenusConfigurationSettingDto : ReadVenusDtoBase
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public bool UpdatePermission { get; set; }
        public bool Hidden { get; set; }
    }
}
