using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Pages;
using Venus.Core.Application.Enums.Systems;
using Venus.Core.Application.Repositories.Interfaces.Cms;
using Venus.Core.Domain.Entities.Systems;
using Venus.Infrastructure.Persistence.Repositories.Base;
using Venus.Infrastructure.Persistence.VenusDbContext;

namespace Venus.Infrastructure.Persistence.Repositories
{
    public class ReadVenusPageTypeRepository : ReadRepositoryBase<VenusPageType>, IReadVenusPageTypeCmsRepository
    {
        public ReadVenusPageTypeRepository(VenusContext db) : base(db)
        {
        }

        public Task<List<VenusPageType>> GetPageTypeAndRelations()
        {
            return base.GetQueryable()
                .Where(x=>x.State == (int)EntityStateEnum.Online)
                .ToListAsync();
        }
    }
}
