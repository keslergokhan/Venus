using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Repositories.Interfaces.Cms
{
    public interface IReadVenusPageAboutCmsRepository : IReadRepository<Venus.Core.Domain.Entities.Systems.VenusPageAbout>
    {
        public Task<List<VenusPageAbout>> GetPageTypeAndRelations();
    }
}
