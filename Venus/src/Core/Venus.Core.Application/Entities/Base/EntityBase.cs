using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Entities.Interfaces;

namespace Venus.Core.Application.Entities.Base
{
    public abstract class EntityBase : IEntity
    {
        public Guid Id { get; set; }
        public byte State { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
