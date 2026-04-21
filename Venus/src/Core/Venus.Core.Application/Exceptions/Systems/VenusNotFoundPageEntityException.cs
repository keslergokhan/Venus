using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venus.Core.Application.Exceptions.Systems
{
    public class VenusNotFoundPageEntityException : Exception
    {
        public VenusNotFoundPageEntityException(string entityName) : base($"${entityName} bağlı bir sayfa bulunamadı !")
        {
        }
    }
}
