using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Repositories.Interfaces.Entities;
using Venus.Core.Domain.Entities;
using Venus.Core.Domain.Entities.Systems;
using Venus.Infrastructure.Persistence.Repositories.Base;
using Venus.Infrastructure.Persistence.VenusDbContext;

namespace Venus.Infrastructure.Persistence.Repositories
{
    public class WriteBlogRepository : WriteRepositoryBase<Blog>, IWriteBlogRepository
    {
        public WriteBlogRepository(VenusContext db) : base(db)
        {
        }
    }
}
