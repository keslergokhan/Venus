using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venus.Core.Application.Exceptions.Cms
{
    public class VenusDataCreationFailedCmsException : Exception
    {
        public VenusDataCreationFailedCmsException()
            : base("Veri veritabanına kaydedilirken beklenmedik bir hata oluştu.")
        { }

        public VenusDataCreationFailedCmsException(string entityName)
            : base($"{entityName} kaydı oluşturulamadı.")
        { }

        public VenusDataCreationFailedCmsException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
