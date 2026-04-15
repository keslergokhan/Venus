using Microsoft.EntityFrameworkCore;
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
        protected readonly VenusContext Context;

        public RepositoryBase(VenusContext db)
        {
            Context = db;
        }

        protected DbSet<T> GetTable<T>() where T : class, IVenusEntity
        {
            return Context.Set<T>();
        }



    }
}
