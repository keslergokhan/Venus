using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Repositories.Interfaces.Cms;
using Venus.Core.Domain.Entities.Systems;
using Venus.Infrastructure.Persistence.Repositories.Base;
using Venus.Infrastructure.Persistence.VenusDbContext;

namespace Venus.Infrastructure.Persistence.Repositories
{
    public class ReadVenusLanguageRepository : ReadRepositoryBase<VenusLanguage>, IReadVenusLanguageCmsRepository
    {
        public ReadVenusLanguageRepository(VenusContext db) : base(db)
        {
        }
    }
}
