using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Exceptions.Base;

namespace Venus.Core.Application.Exceptions.Systems
{
    public class VenusNotFoundPageTypeServiceException : VenusExceptionBase
    {
        public VenusNotFoundPageTypeServiceException(string interfaceFullName):base("NOT_FOUND_PAGE_TYPE_SERVICE",$"{interfaceFullName}, servis bulunamadı !")
        {
            
        }
    }
}
