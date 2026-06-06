using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Repositories.Interfaces.Systems;
using Venus.Core.Domain.Entities.Systems;
using Venus.Infrastructure.Persistence.Repositories.Base;
using Venus.Infrastructure.Persistence.VenusDbContext;

namespace Venus.Infrastructure.Persistence.Repositories
{
    public class VenusPageZoneRepository :
        RepositoryBase<VenusPageZone>, IVenusPageZoneRepository
    {
        public VenusPageZoneRepository(VenusContext db) : base(db)
        {
        }

        public Task<VenusPageZone> GetPageZoneAndWidgetsByPageIdAndKeyAsync(Guid pageId, string key, Guid languageId)
        {
            return GetQueryable()
                .Include(x=>x.ZoneWidgets).ThenInclude(x=>x.Widget)
                .Where(x => x.Key == key && x.PageId == pageId && x.ZoneWidgets.Any(i=>i.LanguageId == languageId))
                .FirstOrDefaultAsync();
        }
    }
}
