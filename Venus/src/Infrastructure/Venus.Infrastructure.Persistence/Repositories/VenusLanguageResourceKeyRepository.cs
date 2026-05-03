using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Enums.Systems;
using Venus.Core.Application.Repositories.Interfaces.Systems;
using Venus.Core.Domain.Entities.Systems;
using Venus.Infrastructure.Persistence.Repositories.Base;
using Venus.Infrastructure.Persistence.VenusDbContext;

namespace Venus.Infrastructure.Persistence.Repositories
{
    public class VenusLanguageResourceKeyRepository : RepositoryBase<Venus.Core.Domain.Entities.Systems.VenusLanguageResourceKey>, IVenusLanguageResourceKeyRepository
    {
        public VenusLanguageResourceKeyRepository(VenusContext db) : base(db)
        {
        }

        public Task<List<VenusLanguageResourceKey>> GetLanguageResourceAndValueAsync()
        {
            return GetTable()
                .Include(x=>x.ResourceValue)
                .Where(x=>x.State != (int)EntityStateEnum.Deleted).OrderBy(x=>x.Key).ToListAsync();
        }
    }
}
