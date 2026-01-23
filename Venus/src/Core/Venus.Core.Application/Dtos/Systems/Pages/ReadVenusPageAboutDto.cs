using Venus.Core.Application.Dtos.Base;
using Venus.Core.Application.Dtos.Systems.EntityDatas;

namespace Venus.Core.Application.Dtos.Systems.Pages
{

    public class ReadVenusPageAboutDto : ReadVenusDtoBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public Guid PageTypeId { get; set; }
        public Guid? PageEntityId { get; set; }
        public ReadVenusEntityPageDto? PageEntity { get; set; }
        public ReadVenusPageTypeDto? PageType { get; set; }

    }
   
}
