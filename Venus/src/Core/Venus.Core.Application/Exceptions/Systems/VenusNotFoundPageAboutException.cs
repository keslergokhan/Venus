using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Exceptions.Base;

namespace Venus.Core.Application.Exceptions.Systems
{
    public class VenusNotFoundPageAboutException : VenusExceptionBase
    {
        public string PageName { get; set; }
        public Guid PageId { get; set; }

        public VenusNotFoundPageAboutException():base("NOT_FOUND_PAGE_ABOUT","Sayfa hakkında bilgiye ulaşılamadı !")
        {
            
        }
        public VenusNotFoundPageAboutException(Guid id,string pageName):base("NOT_FOUND_PAGE_ABOUT",$"Page = {pageName} ulaşılamadı !, PageId = {id}")
        {
            PageName = pageName;
        }


    }
}
