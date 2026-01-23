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
                .Trim() == fullPath.Trim() 
                    && x.State == (int)EntityStateEnum.Online
                    && x.Pages.Any(p=>p.PageAbout.PageType.Title == PageTypeEnum.VenusEntityDetailPage.ToString() && (p.ParentPageId != null || p.ParentPageId == default(Guid))) == false
                )
                .Include(x=>x.Language)
                .Include(x=>x.Pages).ThenInclude(x=>x.PageAbout).ThenInclude(x=>x.PageType)
                .Include(x=>x.Pages).ThenInclude(x=>x.PageAbout).ThenInclude(x=>x.PageEntity)
                .Include(x=>x.ParentUrl).ThenInclude(x=>x.Pages).ThenInclude(x => x.PageAbout).ThenInclude(x => x.PageType)
                .Include(x => x.ParentUrl).ThenInclude(x => x.Pages).ThenInclude(x => x.PageAbout).ThenInclude(x => x.PageEntity)
                .AsSplitQuery().ToListAsync();
        }
    }
}
