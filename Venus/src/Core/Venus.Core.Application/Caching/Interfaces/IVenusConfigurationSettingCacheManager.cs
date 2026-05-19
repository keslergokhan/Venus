using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Settings;

namespace Venus.Core.Application.Caching.Interfaces
{
    public interface IVenusConfigurationSettingCacheManager : IBasicCacheManager<ReadVenusConfigurationSettingDto, string>
    {
    }
}
