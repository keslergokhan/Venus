using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Base;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Dtos.Systems.Pages
{
    public class ReadVenusPageAboutDto : ReadVenusDtoBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public bool IsEntity { get; set; }
        public List<ReadVenusPageDto> Pages { get; set; }
    }
}
