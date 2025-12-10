using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Venus.Core.Application.Results.Interfaces
{
    public interface IResultControl
    {
        public bool IsSuccess { get; }
        [JsonIgnore]
        public Exception Exception { get; }
        public string ErrorMessage { get; }
        public IResultControl Success();
        public IResultControl Fail();
        public IResultControl Fail(string title, string message);
        public IResultControl Fail(Exception exception);
    }
}
