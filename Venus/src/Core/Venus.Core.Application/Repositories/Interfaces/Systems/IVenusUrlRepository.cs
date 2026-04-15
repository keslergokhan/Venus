using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Repositories.Interfaces.Systems
{
    public interface IVenusUrlRepository :  IRepository<VenusUrl>
    {
        public bool UrlCheck(string fullPath);
        public Task<List<VenusUrl>> GetUrlByFullPathAsync(string fullPath);


    }
}
