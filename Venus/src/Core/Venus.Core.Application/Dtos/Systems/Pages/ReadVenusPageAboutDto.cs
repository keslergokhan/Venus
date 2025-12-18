using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Base;
using Venus.Core.Application.Dtos.Systems.EntityDatas;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Dtos.Systems.Pages
{
    public partial class ReadVenusPageAboutDto : ReadVenusDtoBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }

    public partial class ReadVenusPageAboutDto
    {
        public ReadVenusPageTypeDto PageType { get; set; }
        public Guid PageTypeId { get; set; }

        public ReadVenusEntityDataUrlDto? EntityDataUrl { get; set; }
        public Guid? EntityDataUrlId { get; set; }
    }
}
