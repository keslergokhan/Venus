using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venus.Core.Application.Exceptions.Systems
{
    public class VenusNotFoundPageEntitySystemException : Exception
    {
        public VenusNotFoundPageEntitySystemException(string entityName) : base($"${entityName} bağlı bir sayfa bulunamadı !")
        {
        }
    }
}
