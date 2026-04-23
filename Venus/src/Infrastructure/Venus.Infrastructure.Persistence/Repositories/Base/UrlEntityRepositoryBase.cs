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
    public class UrlEntityRepositoryBase<T> : RepositoryBase<T>, IUrlEntityRepository<T>
        where T : class, IVenusEntity, IVenusUrlEntity
    {
        public UrlEntityRepositoryBase(VenusContext db) : base(db)
        {
        }

        public async Task CreateAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity.Url!=null && entity.Url.ParentUrlId != null)
            {
                string baseUrlFullPath = await base.Context.VenusUrl.AsNoTracking().Where(x=>x.Id == entity.Url.ParentUrlId).AsQueryable().Select(x=>x.FullPath).AsQueryable().FirstOrDefaultAsync();    

                entity.Url.FullPath = $"{baseUrlFullPath}{entity.Url.Path}";   
            }
            await base.CreateAsync(entity, cancellationToken);
        }



        public override async Task RemoveAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            var entity = await GetTable().Include(e => e.Url).FirstOrDefaultAsync(e => e.Id == Id, cancellationToken);
            if (entity != null)
            {
                await RemoveAsync(entity, cancellationToken);
            }
        }

        public override Task RemoveAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity.Url !=null)
            {
                entity.Url.State = (int)EntityStateEnum.Deleted;
            }
            return base.RemoveAsync(entity, cancellationToken);
        }

        public override Task<T> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            return GetTable().Include(x=>x.Url).AsQueryable().FirstOrDefaultAsync(e => e.Id == Id, cancellationToken);
        }
    }
}
