using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venus.Core.Application.Exceptions.Cms
{
    public class VenusCmsUserNotFoundException : Exception
    {
        public VenusCmsUserNotFoundException():base("Kullanıcı bulunamadı !")
        {
            
        }
    }
}
