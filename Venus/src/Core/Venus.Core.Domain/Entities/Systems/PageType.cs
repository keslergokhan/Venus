using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Domain.Entities.Base;

namespace Venus.Core.Domain.Entities.Systems
{
    public class PageType : EntityBase
    {
        public string InterfaceType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
