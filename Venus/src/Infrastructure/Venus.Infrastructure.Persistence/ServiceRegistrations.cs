using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Venus.Infrastructure.Persistence.VenusDbContext;

namespace Venus.Infrastructure.Persistence
{
    public static class ServiceRegistrationExtensions
    {
        public static IServiceCollection AddVenusPersistenceServiceRegistration(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<VenusContext>(x=>x.UseSqlServer(configuration.GetConnectionString("VenusConnection")));

            return services;
        }
    }
}
