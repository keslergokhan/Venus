using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Repositories.Interfaces;
using Venus.Core.Domain.Entities;
using Venus.Infrastructure.Persistence.Repositories.Base;
using Venus.Infrastructure.Persistence.VenusDbContext;

namespace Venus.Infrastructure.Persistence.Repositories
{
    public class ReadBlogRepository : ReadRepositoryBase<Blog>, IReadBlogRepositories
    {
        public ReadBlogRepository(VenusContext db) : base(db)
        {
        }
    }
}
