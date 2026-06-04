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


        public Task<VenusWidget> GetWidgetAndWidgetDataByKeyAsync(string key, Guid languageId)
        {
            return GetTable().Where(x => x.Key == key && x.WidgetData.Any(i=>i.LanguageId == languageId)).Include(x => x.WidgetData).FirstOrDefaultAsync();
        }
    }
}
