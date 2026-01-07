using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venus.Core.Application.Exceptions.Base
{
    public abstract class VenusExceptionBase : Exception
    {
        public string ErrorCode { get; }
        public VenusExceptionBase(string errorCode,string message):base(message)
        {
            this.ErrorCode = errorCode;
        }
    }
}
