using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Infrastructure.Persistence.VenusDbContext;
using Venus.Presentation.Client.Core.Services.Routing;

namespace Venus.Presentation.Client.Core
{
    public static class ServiceRegistrationExtensions
    {
        public static IServiceCollection AddVenusPresentationCoreServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<VenusContext>(x => x.UseSqlServer(configuration.GetConnectionString("VenusConnection")));
            services.AddScoped<DefaultDynamicRouteValueTransformer>();
            return services;
        }
    }
}
