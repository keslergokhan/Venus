using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Exceptions.Base;

namespace Venus.Core.Application.Exceptions.Systems
{
    public class VenusNotFoundUrlException : VenusExceptionBase
    {
        public string FullPath { get; }
        public VenusNotFoundUrlException(string fullpath):base("NOT_FOUND_URL",$"{fullpath}, adresine ulaşılamadı !")
        {
            this.FullPath = fullpath;
        }
    }
}
