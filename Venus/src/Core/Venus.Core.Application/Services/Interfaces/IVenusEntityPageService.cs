using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Repositories.Interfaces.Systems;
using Venus.Core.Domain.Entities.Interfaces;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Services.Interfaces
{
    public interface IVenusEntityPageService<TEntity> where TEntity : IVenusUrlEntity, IVenusEntity
    {
        public Task<VenusPage> GetEntityDetailPageByEntityNameAsync(Guid languageId);
    }
}
