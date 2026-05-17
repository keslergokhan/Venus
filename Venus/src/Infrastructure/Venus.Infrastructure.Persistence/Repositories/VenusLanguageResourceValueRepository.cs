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
    public class VenusLanguageResourceValueRepository : RepositoryBase<Venus.Core.Domain.Entities.Systems.VenusLanguageResourceValue>
            , IVenusLanguageResourceValueRepository
    {
        public VenusLanguageResourceValueRepository(VenusContext db) : base(db)
        {
        }

        public Task<VenusLanguageResourceValue> GetByLanguageIdAndResourceKeyIdAsync(Guid languageId, Guid resourceKeyId)
        {
            return GetTable().FirstOrDefaultAsync(x => x.LanguageId == languageId && x.ResourceKeyId == resourceKeyId);
        }
    }
}
