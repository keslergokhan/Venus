using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Base;
using Venus.Core.Application.Dtos.Interfaces;
using Venus.Core.Application.Dtos.Systems.Urls;
using Venus.Core.Domain.Entities.Interfaces;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Dtos.Systems.EntityDatas
{
    public class ReadVenusEntityDataUrlDto : ReadVenusDtoBase, IVenusUrlEntityDto
    {
        public Guid UrlId { get; set; }
        public ReadVenusUrlDto Url { get; set; }
        public string EntityName { get; set; }
        public string EntityClassType { get; set; }
    }
}
