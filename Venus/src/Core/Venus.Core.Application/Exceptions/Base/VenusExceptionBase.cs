using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venus.Core.Application.Exceptions.Base
{
    public abstract class VenusExceptionBase : Exception
    {
        public virtual string ErrorCode { get; }
        protected VenusExceptionBase()
        {
            
        }
        protected VenusExceptionBase(string errorCode)
        {
            this.ErrorCode = errorCode;
        }
        public VenusExceptionBase(string errorCode,string message):base(message)
        {
            this.ErrorCode = errorCode;
        }

        public VenusExceptionBase(string errorCode, string message,Exception innerException) : base(message,innerException)
        {
            this.ErrorCode = errorCode;
        }
    }
}
