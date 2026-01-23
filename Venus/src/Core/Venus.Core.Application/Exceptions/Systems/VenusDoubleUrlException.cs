using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Exceptions.Base;

namespace Venus.Core.Application.Exceptions.Systems
{
    public class VenusDoubleUrlException : VenusExceptionBase
    {
        public VenusDoubleUrlException() : base("VENUS_DOUBLE_URL", "Aynı adresi birden fazla url kullanıyor !")
        {
        }
    }
}
