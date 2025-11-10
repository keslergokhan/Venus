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


        public static IServiceCollection AddVenusApplicationAuthenticationServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            var key = Encoding.UTF8.GetBytes("super-secret-key-very-long-12345!");

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = "venusapp",
                    ValidAudience = "venusapp",
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });
            services.AddAuthorization();
            return services;
        }
    }
}
