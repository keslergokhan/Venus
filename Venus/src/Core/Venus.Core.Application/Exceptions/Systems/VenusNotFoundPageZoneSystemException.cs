using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Exceptions.Base;

namespace Venus.Core.Application.Exceptions.Systems
{
    public class VenusNotFoundPageZoneSystemException : VenusExceptionBase
    {
        public VenusNotFoundPageZoneSystemException() : base("NOT_FOUND_PAGE_ZONE","Zone bulunamadı !") 
        {
        }

        public VenusNotFoundPageZoneSystemException(string key) : base("NOT_FOUND_PAGE_ZONE", $"Zone '{key}' bulunamadı !")
        {
        }

    }
}
