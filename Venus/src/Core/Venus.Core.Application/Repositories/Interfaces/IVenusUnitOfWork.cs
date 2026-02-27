using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venus.Core.Application.Repositories.Interfaces
{
    public interface IVenusUnitOfWork : IDisposable
    {
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        public Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        public Task CommitAsync(CancellationToken cancellationToken = default);
        public Task RollbackAsync(CancellationToken cancellationToken = default);
    }
}
