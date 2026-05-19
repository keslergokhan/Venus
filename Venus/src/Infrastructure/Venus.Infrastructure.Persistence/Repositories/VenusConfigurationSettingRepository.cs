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
    public class VenusConfigurationSettingRepository : RepositoryBase<VenusConfigurationSetting>, IVenusConfigurationSettingRepository
    {
        public VenusConfigurationSettingRepository(VenusContext db) : base(db)
        {
        }
    }
}
