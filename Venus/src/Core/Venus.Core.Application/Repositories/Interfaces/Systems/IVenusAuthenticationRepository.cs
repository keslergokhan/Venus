using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Repositories.Interfaces.Systems
{
    public interface IVenusAuthenticationRepository : IRepository<VenusUser>
    {
        public Task<VenusUser> FindUserAsync(string email,string password);
        public Task<VenusUser> FindUserByIdAsync(Guid id);
    }
}
