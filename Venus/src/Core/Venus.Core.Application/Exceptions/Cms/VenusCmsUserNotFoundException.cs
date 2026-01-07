using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Exceptions.Base;

namespace Venus.Core.Application.Exceptions.Cms
{
    public class VenusCmsUserNotFoundException : VenusExceptionBase
    {
        public VenusCmsUserNotFoundException():base("CMS_USER_NOT_FOUND","Kullanıcı bulunamadı !")
        {
            
        }
    }
}
