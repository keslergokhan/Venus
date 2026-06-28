using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Exceptions.Base;
using Venus.Core.Domain.Entities.Base;

namespace Venus.Core.Application.Exceptions.Cms
{
    public class VenusDataCreationFailedCmsException : VenusExceptionBase
    {
        public VenusDataCreationFailedCmsException()
            : base("DATA_NOT_CREATION","Veri veritabanına kaydedilirken beklenmedik bir hata oluştu.")
        { }

        public VenusDataCreationFailedCmsException(string entityName)
            : base("DATA_NOT_CREATION", $"{entityName} kaydı oluşturulamadı.")
        { }

        public VenusDataCreationFailedCmsException(string message, Exception innerException)
            : base("DATA_NOT_CREATION", message, innerException)
        { }
    }
}
