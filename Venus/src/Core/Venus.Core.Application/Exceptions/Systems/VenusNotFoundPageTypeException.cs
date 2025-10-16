using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venus.Core.Application.Exceptions.Systems
{
    public class VenusNotFoundPageTypeException : Exception
    {
        public VenusNotFoundPageTypeException() : base("Sayfa hakkında bilgiye ulaşılamadı !")
        {
            
        }
    }
}
