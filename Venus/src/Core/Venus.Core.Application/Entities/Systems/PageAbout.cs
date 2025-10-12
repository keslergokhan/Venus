using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Entities.Base;
using Venus.Core.Application.Entities.Interfaces;

namespace Venus.Core.Application.Entities.Systems
{
    public class PageSystem : EntityBase, IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public bool IsEntity { get; set; }
        public PageType PageType { get; set; }
        public Guid PageTypeId { get; set; }
        public ICollection<Page> Pages { get; set; }
    }
}
