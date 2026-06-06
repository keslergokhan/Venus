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
    public class VenusWidgetRepository : RepositoryBase<VenusWidget>, IVenusWidgetRepository
    {
        public VenusWidgetRepository(VenusContext db) : base(db)
        {
        }


        public Task<VenusWidget> GetWidgetAndByKeyAsync(string key)
        {
            return GetQueryable().Where(x => x.Key == key).FirstOrDefaultAsync();
        }
    }
}
