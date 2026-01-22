using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venus.Core.Application.MapsterConfigs
{
    public static class SystemAdapterConfig
    {
        public static void Register()
        {
            TypeAdapterConfig.GlobalSettings.Default
            .PreserveReference(true);
        }
    }
}
