using Venus.Core.Application.Dtos.Base;

namespace Venus.Core.Application.Dtos.Systems.EntityDatas
{
    public class ReadVenusEntityPageDto : ReadVenusDtoBase
    {
        public string EntityName { get; set; }
        public string EntityClassType { get; set; }
    }
}
