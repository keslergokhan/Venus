using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.VenusDbContext.Interfaces
{
    public interface IVenusApplicationDbContext
    {
        public DbSet<VenusUrl> VenusUrl { get; }
    }
}
