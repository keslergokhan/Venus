using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application;
using Venus.Infrastructure.Persistence;
using Venus.Infrastructure.Persistence.VenusDbContext;
using Venus.Presentation.Client.Core.DynamicRoutes;
using Venus.Presentation.Client.Core.PageTypeServices;
using Venus.Presentation.Client.Core.PageTypeServices.Interfaces;

namespace Venus.Presentation.Client.Core
{
    public static class ServiceRegistrationExtensions
    {
        public static IServiceCollection AddVenusPresentationCoreServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            services.AddDbContext<VenusContext>(x => x.UseSqlServer(configuration.GetConnectionString("VenusConnection")));
            services.AddVenusApplicationServiceRegistration(configuration);
            services.AddVenusPersistenceServiceRegistration(configuration);
            services.AddScoped<IVenusDefaultPageTypeService, VenusDefaultPageTypeService>();
            services.AddScoped<VenusDynamicRouteValueTransformer>();
            return services;
        }
    }
}
