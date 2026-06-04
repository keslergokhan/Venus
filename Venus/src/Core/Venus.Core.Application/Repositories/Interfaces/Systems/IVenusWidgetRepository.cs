using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Repositories.Interfaces.Systems
{
    public interface IVenusWidgetRepository : IRepository<VenusWidget>
    {
        public Task<VenusWidget> GetWidgetAndWidgetDataByKeyAsync(string key,Guid languageId);
    }
}
