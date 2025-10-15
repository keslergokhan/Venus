using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Urls;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Repositories.Interfaces.Systems
{
    public interface IReadVenusUrlRepository : IReadRepository<VenusUrl>
    {
        public Task<VenusUrl> GetUrlByFullPathAsync(string fullPath);
    }
}
