using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Repositories.Interfaces;
using Venus.Core.Domain.Entities.Interfaces;
using Venus.Infrastructure.Persistence.VenusDbContext;

namespace Venus.Infrastructure.Persistence.Repositories.Base
{
    public abstract class WriteRepositoryBase<T> : RepositoryBase, IWriteRepository<T>
        where T : class, IVenusEntity
    {
        public WriteRepositoryBase(VenusContext db) : base(db)
        {
        }

        public async Task CreateAsync(T entity, CancellationToken cancellationToken = default)
        {
            entity.CreateDate = DateTime.Now;
            await base.GetTable<T>().AddAsync(entity, cancellationToken);
        }
    }
}
