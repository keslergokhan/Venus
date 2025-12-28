using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venus.Core.Application.Repositories.Interfaces.Systems
{
    public interface IReadVenusPageSystemRepository : IReadRepository<Domain.Entities.Systems.VenusPage>
    {
        public Task<Domain.Entities.Systems.VenusPage> GetPageByUrlIdAsync(Guid urlId);
    }
}
