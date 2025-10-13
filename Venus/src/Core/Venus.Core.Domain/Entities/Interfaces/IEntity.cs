using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venus.Core.Domain.Entities.Interfaces
{
    public interface IEntity
    {
        public Guid Id { get; set; }
        public byte State { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
