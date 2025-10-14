using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Urls;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Dtos.Interfaces
{
    public interface IVenusUrlEntityDto
    {
        public Guid UrlId { get; set; }
        public ReadVenusUrlDto Url { get; set; }
    }
}
