using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Repositories.Interfaces.Cms;
using Venus.Core.Domain.Entities.Systems;
using Venus.Infrastructure.Persistence.Repositories.Base;
using Venus.Infrastructure.Persistence.VenusDbContext;

namespace Venus.Infrastructure.Persistence.Repositories.Cms
{
    public class VenusPageTypeRepository : ReadRepositoryBase<VenusPageType>, IVenusPageTypeRepository
    {
        public VenusPageTypeRepository(VenusContext db) : base(db)
        {
        }
    }
}
