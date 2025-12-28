using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Enums.Systems;
using Venus.Core.Application.Repositories.Interfaces.Systems;
using Venus.Core.Domain.Entities.Systems;
using Venus.Infrastructure.Persistence.Repositories.Base;
using Venus.Infrastructure.Persistence.VenusDbContext;

namespace Venus.Infrastructure.Persistence.Repositories
{
    public class ReadVenusUrlRepository : ReadRepositoryBase<VenusUrl>, IReadVenusUrlSystemRepository
    {
        public ReadVenusUrlRepository(VenusContext db) : base(db)
        {
        }

        public Task<List<VenusUrl>> GetUrlByFullPathAsync(string fullPath)
        {
            return GetQueryable()
                .Where(x => x.FullPath
                .Trim() == fullPath.Trim() && x.State == (int)EntityStateEnum.Online)
                .Include(x=>x.Language)
                .ToListAsync();
        }
    }
}
