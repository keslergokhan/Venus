using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Exceptions.Base;

namespace Venus.Core.Application.Exceptions.Systems
{
    public class VenusNotFoundLanguageException : VenusExceptionBase
    {
        public VenusNotFoundLanguageException() : base("NOT_FOUND_LANGUAGE","Dil ayarına ulaşılamadı !")
        {
            
        }
    }
}
