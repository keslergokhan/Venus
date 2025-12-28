using Venus.Core.Application.Dtos.Base;

namespace Venus.Core.Application.Dtos.Systems.Pages
{

    public class ReadVenusPageTypeDto : ReadVenusDtoBase
    {
        public string InterfaceClassType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
