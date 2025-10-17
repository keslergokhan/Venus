using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.HttpRequests;
using Venus.Core.Application.HttpRequests.Interfaces;
using Venus.Core.Application.VenusDbContext.Interfaces;

namespace Venus.Core.Application
{
    public static class ServiceRegistrations
    {
        public static IServiceCollection AddVenusApplicationServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(x =>
            {
                x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            services.AddScoped<IVenusHttpContext, VenusHttpContext>();
            return services;
        }
    }
}
