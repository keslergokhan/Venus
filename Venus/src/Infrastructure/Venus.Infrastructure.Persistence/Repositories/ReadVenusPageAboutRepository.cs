using Microsoft.EntityFrameworkCore;
using Venus.Core.Application.Enums.Systems;
using Venus.Core.Application.Repositories.Interfaces.Cms;
using Venus.Core.Domain.Entities.Systems;
using Venus.Infrastructure.Persistence.Repositories.Base;
using Venus.Infrastructure.Persistence.VenusDbContext;

namespace Venus.Infrastructure.Persistence.Repositories
{
    public class ReadVenusPageAboutRepository : ReadRepositoryBase<VenusPageAbout>, IReadVenusPageAboutCmsRepository
    {
        public ReadVenusPageAboutRepository(VenusContext db) : base(db)
        {
        }

        public Task<List<VenusPageAbout>> GetPageTypeAndRelations()
        {
            return base.GetQueryable()
                .Where(x => x.State == (byte)EntityStateEnum.Online)
                .Include(x=>x.PageEntity)
                .Include(x=>x.PageType)
                .ToListAsync();
        }
    }
}
