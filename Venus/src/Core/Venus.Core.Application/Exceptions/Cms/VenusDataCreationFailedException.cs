using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venus.Core.Application.Exceptions.Cms
{
    public class VenusDataCreationFailedException : Exception
    {
        public VenusDataCreationFailedException()
            : base("Veri veritabanına kaydedilirken beklenmedik bir hata oluştu.")
        { }

        public VenusDataCreationFailedException(string entityName)
            : base($"{entityName} kaydı oluşturulamadı.")
        { }

        public VenusDataCreationFailedException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
