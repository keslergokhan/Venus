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

        protected DbSet<T> GetTable()
        {
            return Context.Set<T>();
        }

        
        public virtual async Task CreateAsync(T entity, CancellationToken cancellationToken = default)
        {
            entity.CreateDate = DateTime.Now;
            entity.State = (int)EntityStateEnum.Online;
            await GetTable().AddAsync(entity, cancellationToken);
        }


        protected IQueryable<T> GetQueryable()
        {
            return GetTable().AsNoTracking();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> where = null)
        {
            var query = this.GetQueryable();
            if (where != null)
            {
                query =query.Where(where);
            }

            return await query.ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> where = null, CancellationToken cancellationToken = default)
        {
            var query = this.GetQueryable();
            if (where != null)
            {
                query = query.Where(where);
            }

            return await query.ToListAsync(cancellationToken);
        }

        public virtual async Task RemoveAsync(T entity, CancellationToken cancellationToken = default)
        {
            entity.State = (int)EntityStateEnum.Deleted;
            entity.ModifiedDate = DateTime.Now;
            GetTable().Update(entity);
        }


        public virtual async Task RemoveAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            var entity = await GetTable().FirstOrDefaultAsync(e => e.Id == Id, cancellationToken);
            if (entity != null)
            {
                await RemoveAsync(entity, cancellationToken);
            }
        }


        public virtual Task<T> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            return GetTable().FirstOrDefaultAsync(e => e.Id == Id, cancellationToken);
        }

        //public Task<List<T>> GetAllByOnlineAsync(Guid languageId)
        //{
        //    return Context.Set<T>().Where(x => x.State != (int)EntityStateEnum.Deleted && x.LanguageId == languageId).OrderByDescending(x => x.CreateDate).ToListAsync();
        //}
    }
}
