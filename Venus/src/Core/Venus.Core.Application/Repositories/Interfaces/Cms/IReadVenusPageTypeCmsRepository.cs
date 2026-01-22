using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Pages;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Repositories.Interfaces.Cms
{
    public interface IReadVenusPageTypeCmsRepository : IReadRepository<VenusPageType>
    {
        public Task<List<VenusPageType>> GetPageTypeAndRelations();
    }
}
