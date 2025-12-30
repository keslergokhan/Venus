using Venus.Core.Application.Dtos.Base;
using Venus.Core.Application.Dtos.Systems.Urls;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Dtos.Systems.Pages
{

    public partial class ReadVenusPageTypeDto : ReadVenusDtoBase
    {
        public string InterfaceClassType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

    }

    public partial class ReadVenusPageTypeDto : ReadVenusDtoBase
    {
        public List<ReadVenusUrlDto> Urls { get; set; } = new List<ReadVenusUrlDto>();
    }
}
