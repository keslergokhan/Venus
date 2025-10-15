using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Repositories.Interfaces;
using Venus.Core.Application.VenusDbContext.Interfaces;
using Venus.Core.Domain.Entities.Interfaces;
using Venus.Infrastructure.Persistence.VenusDbContext;

namespace Venus.Infrastructure.Persistence.Repositories.Base
{
    public abstract class ReadRepositoryBase<T>: IReadRepository<T> 
        where T :class,IVenusEntity
        
    {
        private readonly VenusContext _db;

        public ReadRepositoryBase(VenusContext db)
        {
            _db = db;
        }

        protected IQueryable<T> GetCollection()
        {
            return _db.Set<T>().AsQueryable();
        }

        public Task<List<T>> GetAllAsync(Expression<Func<T, bool>> where = null)
        {
            var query = this.GetCollection();
            if (where!=null)
            {
                query.Where(where);
            }
            
            return query.ToListAsync();
                
        }
    }
}
