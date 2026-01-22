using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Repositories.Interfaces.Systems;
using Venus.Core.Domain.Entities.Systems;
using Venus.Infrastructure.Persistence.Repositories.Base;
using Venus.Infrastructure.Persistence.VenusDbContext;

namespace Venus.Infrastructure.Persistence.Repositories
{
    public class ReadVenusPageRepository : ReadRepositoryBase<VenusPage>, IReadVenusPageSystemRepository
    {
        public ReadVenusPageRepository(VenusContext db) : base(db)
        {
        }

        public async Task<VenusPage> GetPageByUrlIdAsync(Guid urlId)
        {
            return base.GetQueryable()
                .Include(x=>x.Url)
                .ThenInclude(x=>x.PageType).ThenInclude(x=>x.PageAbout)
                .FirstOrDefault(p => p.UrlId == urlId);
        }
    }
}
