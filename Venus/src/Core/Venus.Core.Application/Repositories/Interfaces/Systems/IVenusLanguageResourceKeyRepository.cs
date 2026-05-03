using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Repositories.Interfaces.Systems
{
    public interface IVenusLanguageResourceKeyRepository : IRepository<Venus.Core.Domain.Entities.Systems.VenusLanguageResourceKey>
    {
        public Task<List<VenusLanguageResourceKey>> GetLanguageResourceAndValueAsync();
    }
}
