using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Repositories.Interfaces.Entities;
using Venus.Core.Domain.Entities;
using Venus.Infrastructure.Persistence.Repositories.Base;
using Venus.Infrastructure.Persistence.VenusDbContext;

namespace Venus.Infrastructure.Persistence.Repositories
{
    public class BlogRepository : UrlEntityRepositoryBase<Blog>, IBlogRepository
    {
        public BlogRepository(VenusContext db) : base(db)
        {
        }
    }
}
