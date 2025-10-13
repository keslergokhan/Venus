using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venus.Core.Domain.Entities.Systems.ManyToMany
{
    public class Url_PageType
    {
        public Guid UrlId { get; set; }
        public Url Url { get; set; }
        public Guid PageTypeId { get; set; }
        public PageType PageType { get; set; }
    }
}
