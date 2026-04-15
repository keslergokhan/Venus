using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Domain.Entities.Interfaces;

namespace Venus.Core.Application.Repositories.Interfaces
{
    public interface IWriteRepository<T>
        where T : class, IVenusEntity
    {
        
    }
}
