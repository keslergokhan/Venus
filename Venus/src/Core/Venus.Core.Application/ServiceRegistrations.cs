using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.HttpRequests;
using Venus.Core.Application.HttpRequests.Interfaces;
using Venus.Core.Application.Services;
using Venus.Core.Application.Services.Interfaces;
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
            services.AddScoped<IFileManagerService,FileManagerService>();
            return services;
        }


        public static IServiceCollection AddVenusApplicationAuthenticationServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            string symmetricSecurityKey = configuration.GetValue<string>("SymmetricSecurityKey");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(symmetricSecurityKey));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = securityKey,
                    ValidateIssuer = false,
                    ValidIssuer = "venusapp",
                    ValidateAudience = true,
                    ValidAudience = "venusapp",
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(5) // süresi dolmuş token hemen geçersiz olsun
                };
            });
            services.AddAuthorization();
            return services;
        }
    }
}
