using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Enums.Systems;
using Venus.Core.Application.Repositories.Interfaces;
using Venus.Core.Domain.Entities.Interfaces;
using Venus.Infrastructure.Persistence.VenusDbContext;

namespace Venus.Infrastructure.Persistence.Repositories.Base
{
    public class ReadCustomRepositoryBase<T> : ReadRepositoryBase<T>, IReadCustomRepository<T>
        where T : class, IVenusEntity, IVenusLanguageEntity, IVenusUrlEntity
    {
        public ReadCustomRepositoryBase(VenusContext db) : base(db)
        {
        }

        public Task<List<T>> GetAllByOnlineAsync(Guid languageId)
        {
            return base.Context.Set<T>().Where(x => x.State != (int)EntityStateEnum.Deleted && x.LanguageId == languageId).OrderByDescending(x=>x.CreateDate).ToListAsync();
        }
    }
}
