using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Base;
using Venus.Core.Application.Dtos.Interfaces;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Dtos.Systems.Pages
{
    public class ReadVenusPageTypeDto : ReadVenusDtoBase
    {
        public string InterfaceClassType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<ReadVenusPageAboutDto> PageAbouts { get; set; }
    }
}
