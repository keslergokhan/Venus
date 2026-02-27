using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venus.Core.Application.Features.Interfaces
{
    public interface ILocalizedRequest
    {
        public Guid LanguageId { get; set; }
    }
}
