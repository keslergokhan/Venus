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
using Venus.Core.Application.Caching;
using Venus.Infrastructure.Persistence;
using Venus.Infrastructure.Persistence.VenusDbContext;
using Venus.Presentation.Client.Core.DynamicRoutes;
using Venus.Presentation.Client.Core.HtmlCustomTagHelpers;
using Venus.Presentation.Client.Core.HtmlCustomTagParser;
using Venus.Presentation.Client.Core.PageTypeServices;
using Venus.Presentation.Client.Core.PageTypeServices.Interfaces;
using Venus.Presentation.Client.Core.VenusTagHelpers;

namespace Venus.Presentation.Client.Core
{
    public static class ServiceRegistrationExtensions
    {
        public static IServiceCollection AddVenusPresentationCoreServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            services.AddVenusApplicationServiceRegistration(configuration);
            services.AddVenusPersistenceServiceRegistration(configuration);
            services.AddScoped<IVenusDefaultPageTypeService, VenusDefaultPageTypeService>();
            services.AddScoped<IVenusEntityListPageTypeService, VenusEntityListPageTypeService>();
            services.AddScoped<IVenusEntityDetailPageTypeService, VenusEntityDetailPageTypeService>();
            services.AddScoped<VenusDynamicRouteValueTransformer>();
            services.AddVenusMemoryCacheRegistration(configuration, TimeSpan.FromMinutes(10));

            services.AddScoped<IVenusHtmlCustomTagHelper, VenusWidgetHtmlCustomTagHelper>();
            services.AddScoped<IVenusHtmlCustomTagHelper, VenusLangaugeResourceHtmlCustomTagHelper>();
            services.AddScoped<IHtmlCustomTagParserAndRenderFactory, HtmlCustomTagParserAndRenderFactory>();
            services.AddScoped<IVenusScribanManager, VenusScribanManager>();
            return services;
        }
    }
}
