using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venus.Core.Application.Exceptions.Systems
{
    public class VenusNotFoundLanguageException : Exception
    {
        public VenusNotFoundLanguageException() : base("Dil ayarına ulaşılamadı !")
        {
            
        }
    }
}
