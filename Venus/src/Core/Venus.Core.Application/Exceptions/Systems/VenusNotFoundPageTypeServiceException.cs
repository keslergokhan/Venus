using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venus.Core.Application.Exceptions.Systems
{
    public class VenusNotFoundPageTypeServiceException : Exception
    {
        public VenusNotFoundPageTypeServiceException(string interfaceFullName):base($"{interfaceFullName}, servis bulunamadı !")
        {
            
        }
    }
}
