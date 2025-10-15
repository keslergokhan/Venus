using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venus.Core.Application.Exceptions.Systems
{
    public class VenusNotFoundPageException : Exception
    {
        public string FullPath { get; }
        public VenusNotFoundPageException(string fullPath) : base($"{fullPath}, adresine bağlı sayfa bulunamadı !")
        {
            this.FullPath = fullPath;
        }
    }
}
