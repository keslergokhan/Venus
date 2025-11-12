using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Domain.Entities.Interfaces;
using Venus.Infrastructure.Persistence.VenusDbContext;

namespace Venus.Infrastructure.Persistence.Repositories.Base
{
    public abstract class RepositoryBase
    {
        private readonly VenusContext _db;

        public RepositoryBase(VenusContext db)
        {
            _db = db;
        }

        protected IQueryable<T> GetQueryable<T>() where T : class, IVenusEntity
        {
            return _db.Set<T>().AsQueryable();
        }
    }
}
