using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Enums.Systems;
using Venus.Core.Application.Repositories.Interfaces.Cms;
using Venus.Core.Domain.Entities.Systems;
using Venus.Infrastructure.Persistence.Repositories.Base;
using Venus.Infrastructure.Persistence.VenusDbContext;

namespace Venus.Infrastructure.Persistence.Repositories.Cms
{
    public class VenusAuthenticationRepository : RepositoryBase, IVenusAuthenticationRepository
    {
        public VenusAuthenticationRepository(VenusContext db) : base(db)
        {

        }

        public Task<VenusUser> FindUserAsync(string email, string password)
        {
            return base.GetQueryable<VenusUser>()
                .Where(x => 
                x.Email.Trim().ToLower() == email.ToLower().Trim() 
                && x.Password.Trim() == password.Trim()
                && x.State == (int)EntityStateEnum.Online)
                .FirstOrDefaultAsync();
        }

        public Task<VenusUser> FindUserByIdAsync(Guid id)
        {
            return base.GetQueryable<VenusUser>().FirstOrDefaultAsync(x=>x.Id == id);
        }
    }
}
