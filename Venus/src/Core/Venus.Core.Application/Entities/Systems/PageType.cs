using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Entities.Base;

namespace Venus.Core.Application.Entities.Systems
{
    public class PageType : EntityBase
    {
        public string InterfaceType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
