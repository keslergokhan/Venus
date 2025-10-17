using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venus.Core.Application.Exceptions.Systems
{
    public class VenusNotFoundPageAboutException : Exception
    {
        public string PageName { get; set; }
        public Guid PageId { get; set; }

        public VenusNotFoundPageAboutException(Guid id,string pageName):base($"Page = {pageName} ulaşılamadı !, PageId = {id}")
        {
            PageName = pageName;
        }


    }
}
