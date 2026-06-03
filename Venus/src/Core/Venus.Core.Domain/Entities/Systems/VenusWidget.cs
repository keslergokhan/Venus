using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Domain.Entities.Base;

namespace Venus.Core.Domain.Entities.Systems
{
    public partial class VenusWidget : VenusEntityBase
    {
        public string Key { get; set; }
        public string Template { get; set; }
        public string TemplateDataSchema { get; set; }
    }

    public partial class VenusWidget
    {
        public ICollection<VenusWidgetData> WidgetData { get; set; }
    }
}
