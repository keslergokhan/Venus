using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Domain.Entities.Base;
using Venus.Core.Domain.Entities.Interfaces;

namespace Venus.Core.Domain.Entities.Systems
{
    public partial class VenusPageEntity:VenusEntityBase
    {
        public string EntityName {  get; set; }
        public string EntityClassType { get; set; }
    }
}
