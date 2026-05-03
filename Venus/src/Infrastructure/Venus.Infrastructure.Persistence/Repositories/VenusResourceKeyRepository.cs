using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Repositories.Interfaces.Systems;
using Venus.Infrastructure.Persistence.Repositories.Base;
using Venus.Infrastructure.Persistence.VenusDbContext;

namespace Venus.Infrastructure.Persistence.Repositories
{
    public class VenusResourceKeyRepository : RepositoryBase<Venus.Core.Domain.Entities.Systems.VenusLanguageResourceKey>, IVenusResourceKeyRepository
    {
        public VenusResourceKeyRepository(VenusContext db) : base(db)
        {
        }
    }
}
