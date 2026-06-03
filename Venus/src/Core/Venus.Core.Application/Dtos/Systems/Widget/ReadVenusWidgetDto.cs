using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Base;

namespace Venus.Core.Application.Dtos.Systems.Widget
{
    public class ReadVenusWidgetDto : ReadVenusDtoBase
    {
        public string Key { get; set; }
        public string Template { get; set; }
        public string TemplateDataSchema { get; set; }
    }
}
