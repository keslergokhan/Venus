using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Repositories.Interfaces.Systems
{
    public interface IVenusLanguageResourceValueRepository : IRepository<Venus.Core.Domain.Entities.Systems.VenusLanguageResourceValue>
    {
        public Task<VenusLanguageResourceValue> GetByLanguageIdAndResourceKeyIdAsync(Guid languageId, Guid resourceKeyId);
    }
}
