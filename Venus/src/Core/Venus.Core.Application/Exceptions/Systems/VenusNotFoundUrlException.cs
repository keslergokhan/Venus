using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venus.Core.Application.Exceptions.Systems
{
    public class VenusNotFoundUrlException : Exception
    {
        public string FullPath { get; }
        public VenusNotFoundUrlException(string fullpath):base($"{fullpath}, adresine ulaşılamadı !")
        {
            this.FullPath = fullpath;
        }
    }
}
