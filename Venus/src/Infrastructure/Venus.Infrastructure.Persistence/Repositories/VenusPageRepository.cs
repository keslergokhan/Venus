using Microsoft.EntityFrameworkCore;
using Venus.Core.Application.Repositories.Interfaces.Systems;
using Venus.Core.Domain.Entities.Systems;
using Venus.Infrastructure.Persistence.Repositories.Base;
using Venus.Infrastructure.Persistence.VenusDbContext;

namespace Venus.Infrastructure.Persistence.Repositories
{
    public class VenusPageRepository : RepositoryBase<VenusPage>, IVenusPageRepository
    {
        public VenusPageRepository(VenusContext db) : base(db)
        {
        }

        public async Task<VenusPage> GetPageByUrlIdAsync(Guid urlId)
        {
            return base.GetQueryable()
                .Include(x=>x.Url)
                .FirstOrDefault(p => p.UrlId == urlId);
        }
    }
}
