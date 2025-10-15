using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Domain.Entities.Interfaces;

namespace Venus.Core.Application.Repositories.Interfaces
{
    public interface IReadRepository<T> 
        where T : class,IVenusEntity
    {
        public Task<List<T>> GetAllAsync(Expression<Func<T,bool>> where=null);
    }
}
