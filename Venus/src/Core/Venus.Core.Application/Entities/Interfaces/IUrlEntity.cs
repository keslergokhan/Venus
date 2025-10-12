using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Entities.Systems;

namespace Venus.Core.Application.Entities.Interfaces
{
    public interface IUrlEntity
    {
        public Guid UrlId { get; set; }
        public Url Url { get; set; }
    }
}
