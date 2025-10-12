using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Entities.Base;
using Venus.Core.Application.Entities.Interfaces;

namespace Venus.Core.Application.Entities.Systems
{
    public class EntityDataUrl:EntityBase,IEntity,IUrlEntity
    {
        public Guid UrlId { get; set; }
        public Url Url { get; set; }
        public string EntityName {  get; set; }
        public string EntityType { get; set; }

    }
}
