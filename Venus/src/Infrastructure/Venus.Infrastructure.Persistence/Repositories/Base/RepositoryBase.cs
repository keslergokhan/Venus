using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Enums.Systems;
using Venus.Core.Application.Repositories.Interfaces;
using Venus.Core.Domain.Entities.Interfaces;
using Venus.Infrastructure.Persistence.VenusDbContext;

namespace Venus.Infrastructure.Persistence.Repositories.Base
{
    public abstract class RepositoryBase<T> : IRepository<T>
        where T : class, IVenusEntity
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

        public async Task CreateAsync(T entity, CancellationToken cancellationToken = default)
        {
            entity.CreateDate = DateTime.Now;
            entity.State = (int)EntityStateEnum.Online;
            await GetTable<T>().AddAsync(entity, cancellationToken);
        }

        protected IQueryable<T> GetQueryable()
        {
            return GetTable<T>().AsNoTracking();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> where = null)
        {
            var query = this.GetQueryable();
            if (where != null)
            {
                query.Where(where);
            }

            return await query.ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> where = null, CancellationToken cancellationToken = default)
        {
            var query = this.GetQueryable();
            if (where != null)
            {
                query.Where(where);
            }

            return await query.ToListAsync(cancellationToken);
        }

        //public Task<List<T>> GetAllByOnlineAsync(Guid languageId)
        //{
        //    return Context.Set<T>().Where(x => x.State != (int)EntityStateEnum.Deleted && x.LanguageId == languageId).OrderByDescending(x => x.CreateDate).ToListAsync();
        //}
    }
}
