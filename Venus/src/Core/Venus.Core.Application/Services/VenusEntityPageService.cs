using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Exceptions.Systems;
using Venus.Core.Application.Repositories.Interfaces.Systems;
using Venus.Core.Application.Services.Interfaces;
using Venus.Core.Domain.Entities.Interfaces;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Services
{
    public class VenusEntityPageService<TEntity> : IVenusEntityPageService<TEntity>
        where TEntity : IVenusUrlEntity, IVenusEntity
    {

        private readonly IVenusPageRepository _venusPageRepository;

        public string EntityFullName => typeof(TEntity).FullName;

        public VenusEntityPageService(IVenusPageRepository venusPageRepository)
        {
            _venusPageRepository = venusPageRepository;
        }

        public async Task<VenusPage> GetEntityDetailPageByEntityNameAsync(Guid languageId)
        {
            VenusPage venusPage = await _venusPageRepository.GetEntityDetailPageByEntityNameAsync(EntityFullName, languageId);
            if (venusPage==null)
            {
                throw new VenusNotFoundPageEntityException(EntityFullName);

            }
            return venusPage;
        }
    }
}
