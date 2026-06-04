using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Exceptions.Base;

namespace Venus.Core.Application.Exceptions.Systems
{
    public class VenusNotFoundUrlSystemException : VenusExceptionBase
    {
        public string FullPath { get; }
        public VenusNotFoundUrlSystemException(string fullpath):base("NOT_FOUND_URL",$"{fullpath}, adresine ulaşılamadı !")
        {
            this.FullPath = fullpath;
        }
    }
}
