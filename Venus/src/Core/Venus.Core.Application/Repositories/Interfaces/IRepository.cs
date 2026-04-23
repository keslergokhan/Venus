using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Domain.Entities.Interfaces;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Repositories.Interfaces
{
    public interface IRepository<T>
        where T : class, IVenusEntity
    {
        public Task<List<T>> GetAllAsync(Expression<Func<T, bool>> where = null, CancellationToken cancellationToken = default);
        public Task<T> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default);
        public Task CreateAsync(T entity, CancellationToken cancellationToken = default);
        public Task RemoveAsync(T entity, CancellationToken cancellationToken = default);
        public Task RemoveAsync(Guid Id, CancellationToken cancellationToken = default);
    }

    public interface IUrlEntityRepository<T> : IRepository<T>
        where T : class, IVenusEntity, IVenusUrlEntity
    {
    }
}
