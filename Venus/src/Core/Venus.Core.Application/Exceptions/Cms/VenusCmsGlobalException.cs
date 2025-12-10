using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venus.Core.Application.Exceptions.Cms
{
    public class VenusCmsGlobalException : Exception
    {
        public VenusCmsGlobalException(string message):base(message)
        {
            
        }
    }
}
