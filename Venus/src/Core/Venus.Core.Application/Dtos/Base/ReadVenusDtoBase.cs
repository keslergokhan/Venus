using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Interfaces;

namespace Venus.Core.Application.Dtos.Base
{
    public abstract class ReadVenusDtoBase : IReadDtoBase
    {
        public Guid Id { get; set; }
    }
}
