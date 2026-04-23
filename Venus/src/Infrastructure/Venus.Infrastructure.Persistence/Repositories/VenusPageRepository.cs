using Microsoft.EntityFrameworkCore;
using Venus.Core.Application.Enums.Systems;
using Venus.Core.Application.Repositories.Interfaces.Systems;
using Venus.Core.Domain.Entities.Systems;
using Venus.Infrastructure.Persistence.Repositories.Base;
using Venus.Infrastructure.Persistence.VenusDbContext;

namespace Venus.Infrastructure.Persistence.Repositories
{
    public class VenusPageRepository : RepositoryBase<VenusPage>, IVenusPageRepository
    {
        public VenusPageRepository(VenusContext db) : base(db)
        {
        }

        public Task<List<VenusPage>> GetAllEntityDetailPageByEntityNameAsync(Guid languageId)
        {
            return base.GetQueryable().Where(x => x.LanguageId == languageId && x.PageAbout.PageType.Title == PageTypeEnum.VenusEntityDetailPage.ToString()).Include(x => x.Url).AsQueryable().ToListAsync();
        }

        public Task<VenusPage?> GetEntityDetailPageByEntityNameAsync(string entityTypeFullName,Guid languageId)
        {
            return base.GetQueryable().Where(x => x.LanguageId == languageId && x.PageAbout.PageEntity.EntityClassType == entityTypeFullName && x.PageAbout.PageType.Title == PageTypeEnum.VenusEntityDetailPage.ToString()).Include(x => x.Url).AsQueryable().FirstOrDefaultAsync();
        }



        public Task<VenusPage> GetPageByUrlIdAsync(Guid urlId)
        {
            return base.GetQueryable()
                .Include(x=>x.Url)
                .FirstOrDefaultAsync(p => p.UrlId == urlId);
        }
    }
}
