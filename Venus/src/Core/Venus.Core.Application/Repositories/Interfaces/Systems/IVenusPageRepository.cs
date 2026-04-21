using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Repositories.Interfaces.Systems
{
    public interface IVenusPageRepository : IRepository<VenusPage>
    {
        public Task<Domain.Entities.Systems.VenusPage> GetPageByUrlIdAsync(Guid urlId);
        public Task<VenusPage?> GetEntityDetailPageByEntityNameAsync(string entityTypeFullName);
    }
}
    