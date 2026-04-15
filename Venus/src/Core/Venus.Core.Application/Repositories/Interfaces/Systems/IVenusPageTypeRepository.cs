using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Repositories.Interfaces.Systems
{
    public interface IVenusPageTypeRepository: IRepository<VenusPageType>
    {
        public Task<List<VenusPageType>> GetPageTypeAndRelations();
    }
}
