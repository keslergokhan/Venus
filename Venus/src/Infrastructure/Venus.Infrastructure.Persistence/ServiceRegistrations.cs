using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Venus.Core.Application.Enums.Systems;
using Venus.Core.Application.Repositories.Interfaces;
using Venus.Core.Application.Repositories.Interfaces.Systems;
using Venus.Core.Application.VenusDbContext.Interfaces;
using Venus.Core.Domain.Entities.Systems;
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
            services.AddScoped<VenusContext>();
            services.AddVenusPersistenceServiceRegistration();

            return services;
        }


        #region Other
        
        private static void AddVenusPersistenceServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IReadVenusUrlRepository, ReadVenusUrlRepository>();
            services.AddStartData();
        }

        private static void AddStartData(this IServiceCollection services)
        {
            try
            {
                IServiceProvider serviceProvider = services.BuildServiceProvider();

                VenusContext db = serviceProvider.GetService<VenusContext>();

                if (!db.VenusLanguage.Any(x => x.CountryCode == "tr"))
                {
                    db.VenusLanguage.Add(new VenusLanguage()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Türkçe",
                        CountryCode = "tr",
                        CreateDate = DateTime.Now,
                        Culture = "tr-TR",
                        Currency = "TL",
                        ModifiedDate = null,
                        Sort = 0,
                        State = (int)EntityStateEnum.Online
                    });
                    db.SaveChanges();
                }

                VenusLanguage language = db.VenusLanguage.FirstOrDefault(x => x.CountryCode == "tr");

                if (!db.VenusPageType.Any(x => x.InterfaceClassType == "Venus.Presentation.Client.Core.PageTypeServices.Interfaces.IVenusDefaultPageTypeService"))
                {
                    db.VenusPageType.Add(new Core.Domain.Entities.Systems.VenusPageType()
                    {
                        Title = "VenusDefaultPage",
                        CreateDate = DateTime.Now,
                        Description = "Varsayılan temel içerik sayfası",
                        Id = Guid.NewGuid(),
                        State = (int)EntityStateEnum.Online,
                        InterfaceClassType = "Venus.Presentation.Client.Core.PageTypeServices.Interfaces.IVenusDefaultPageTypeService",
                        ModifiedDate = null,
                    });

                    db.SaveChanges();
                }

                if (!db.VenusPageAbout.Any(x => x.Controller == "VenusDefaultPageController"))
                {
                    db.VenusPageAbout.Add(new VenusPageAbout()
                    {
                        Id = Guid.NewGuid(),
                        Controller = "VenusDefaultPageController",
                        Action = "Index",
                        CreateDate = DateTime.Now,
                        Description = "Varsayılan İçerik Altyapısı",
                        IsEntity = false,
                        ModifiedDate = null,
                        Name = "DefaultPage",
                        State = (int)EntityStateEnum.Online,
                    });
                    db.SaveChanges();
                }

                VenusPageAbout pageAbout = db.VenusPageAbout.FirstOrDefault(x => x.Controller == "VenusDefaultPageController");

                VenusPageType pageType = db.VenusPageType.FirstOrDefault(x => x.InterfaceClassType == "IVenusDefaultPageTypeServices");

                if (!db.VenusUrl.Any(x => x.FullPath == "/hakkimizda"))
                {
                    db.VenusUrl.Add(new VenusUrl()
                    {
                        FullPath = "/hakkimizda",
                        CreateDate = DateTime.Now,
                        Id = Guid.NewGuid(),
                        IsEntity = false,
                        LanguageId = language.Id,
                        State = (int)EntityStateEnum.Online,
                        PageTypeId = pageType.Id,
                        ParentUrl = null,
                        SubUrls = null,
                        Path = "/hakkimizda",
                        Pages = new List<VenusPage>()
                    {
                        new VenusPage()
                        {
                            Id = pageType.Id,
                            LanguageId = language.Id,
                            Name = "Hakkimizda",
                            CreateDate= DateTime.Now,
                            PageAboutId = pageAbout.Id,
                            State= (int)EntityStateEnum.Online,
                            ParentPage = null,
                            SubPages = null,
                        }
                    }
                    });
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            

        }

        #endregion EndOther
    }
}
