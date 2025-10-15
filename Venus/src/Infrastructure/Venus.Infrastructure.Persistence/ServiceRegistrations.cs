using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Venus.Core.Application.Repositories.Interfaces;
using Venus.Core.Application.Repositories.Interfaces.Systems;
using Venus.Core.Application.VenusDbContext.Interfaces;
using Venus.Infrastructure.Persistence.Repositories.Base;
using Venus.Infrastructure.Persistence.Repositories.Systems;
using Venus.Infrastructure.Persistence.VenusDbContext;

namespace Venus.Infrastructure.Persistence
{
    public static class ServiceRegistrationExtensions
    {
        public static IServiceCollection AddVenusPersistenceServiceRegistration(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<VenusContext>(x=>x.UseSqlServer(configuration.GetConnectionString("VenusConnection")));
            services.AddScoped<IVenusApplicationDbContext, VenusContext>();

            return services;
        }

        private static void AddVenusPersistenceServiceRegistration(IServiceCollection services)
        {
            services.AddScoped(typeof(IReadRepository<>),typeof(ReadRepositoryBase<>));
            services.AddScoped<IReadVenusUrlRepository, ReadVenusUrlRepository>();
        }
    }
}
