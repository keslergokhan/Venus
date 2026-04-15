using Venus.Core.Application.Repositories.Interfaces.Systems;
using Venus.Core.Domain.Entities.Systems;
using Venus.Infrastructure.Persistence.Repositories.Base;
using Venus.Infrastructure.Persistence.VenusDbContext;

namespace Venus.Infrastructure.Persistence.Repositories
{
    public class VenusLanguageRepository :RepositoryBase<VenusLanguage>, IVenusLanguageRepository
    {
        public VenusLanguageRepository(VenusContext db) : base(db)
        {
        }
    }
}
