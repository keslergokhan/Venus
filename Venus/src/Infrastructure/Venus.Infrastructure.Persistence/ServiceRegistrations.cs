using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Venus.Core.Application.Enums.Systems;
using Venus.Core.Application.Repositories.Interfaces;
using Venus.Core.Application.Repositories.Interfaces.Cms;
using Venus.Core.Application.Repositories.Interfaces.Systems;
using Venus.Core.Application.VenusDbContext.Interfaces;
using Venus.Core.Domain.Entities;
using Venus.Core.Domain.Entities.Systems;
using Venus.Infrastructure.Persistence.Repositories;
using Venus.Infrastructure.Persistence.Repositories.Cms;
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
            services.AddScoped<IVenusAuthenticationRepository, VenusAuthenticationRepository>();
            services.AddScoped<IVenusPageTypeRepository, VenusPageTypeRepository>();
            services.AddScoped<IReadBlogRepositories, ReadBlogRepository>();
            //services.AddStartData();
            
        }

        private static void AddStartData(this IServiceCollection services)
        {
            try
            {
                IServiceProvider serviceProvider = services.BuildServiceProvider();

                VenusContext db = serviceProvider.GetService<VenusContext>();

                if (!db.VenusUser.Any(x=>x.Email == "gokhan@gmail.com"))
                {
                    db.VenusUser.Add(new VenusUser()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Gökhan",
                        Surname = "Kesler",
                        Email = "gokhan@gmail.com",
                        CreateDate = DateTime.Now,
                        ModifiedDate = null,
                        Password = "123456",
                        State = 1
                    });
                    db.SaveChanges();
                }

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
                        ModifiedDate = null,
                        Name = "DefaultPage",
                        State = (int)EntityStateEnum.Online,
                        PageTypeId = db.VenusPageType.FirstOrDefault(x=>x.Title == "VenusDefaultPage").Id,
                        EntityDataUrl = null,
                    });
                    db.SaveChanges();
                }

                VenusPageAbout pageAbout = db.VenusPageAbout.FirstOrDefault(x => x.Controller == "VenusDefaultPageController");

                VenusPageType pageType = db.VenusPageType.FirstOrDefault(x => x.Title == "VenusDefaultPage");

                if (!db.VenusUrl.Any(x => x.FullPath == "/hakkimizda"))
                {
                    var url = new VenusUrl()
                    {
                        FullPath = "/hakkimizda",
                        CreateDate = DateTime.Now,
                        Id = Guid.NewGuid(),
                        LanguageId = language.Id,
                        State = (int)EntityStateEnum.Online,
                        PageTypeId = pageType.Id,
                        ParentUrl = null,
                        SubUrls = null,
                        UrlType = (short)UrlTypeEnum.Content,
                        Path = "/hakkimizda",
                        Pages = new List<VenusPage>()
                        {
                            new VenusPage()
                            {
                                Id = pageType.Id,
                                Description = "Hakkimizda",
                                LanguageId = language.Id,
                                Name = "Hakkimizda",
                                CreateDate= DateTime.Now,
                                PageAboutId = pageAbout.Id,
                                State= (int)EntityStateEnum.Online,
                                ParentPage = null,
                                SubPages = null,
                            }
                        }
                    };

                    db.VenusUrl.Add(url);
                    db.SaveChanges();
                }

                if (!db.Blog.Any(x=>x.Title == "test-blog"))
                {
                    if (!db.VenusPageType.Any(x=>x.Title == "VenusEntityListPage"))
                    {
                        db.VenusPageType.Add(new VenusPageType()
                        {
                            Id = Guid.NewGuid(),
                            Title = "VenusEntityListPage",
                            InterfaceClassType = "Venus.Presentation.Client.Core.PageTypeServices.Interfaces.IVenusEntityListPageTypeService",
                            CreateDate = DateTime.Now,
                            Description = "Varsayılan list sayfası",
                            State = (int)EntityStateEnum.Online,
                        });
                        db.SaveChanges();
                    }

                    if (!db.VenusPageType.Any(x => x.Title == "VenusEntityDetailPage"))
                    {
                        db.VenusPageType.Add(new VenusPageType()
                        {
                            Id = Guid.NewGuid(),
                            Title = "VenusEntityDetailPage",
                            InterfaceClassType = "Venus.Presentation.Client.Core.PageTypeServices.Interfaces.IVenusEntityDetailPageTypeService",
                            CreateDate = DateTime.Now,
                            Description = "Varsayılan list sayfası",
                            State = (int)EntityStateEnum.Online,
                        });
                        db.SaveChanges();
                    }

                    Type blog = typeof(Blog);
                    if (!db.VenusEntityDataUrl.Any(x=>x.EntityName == "Blog"))
                    {
                        db.VenusEntityDataUrl.Add(new VenusEntityDataUrl()
                        {
                            Id = Guid.NewGuid(),
                            EntityName = blog.Name,
                            EntityClassType = blog.FullName,
                            CreateDate = DateTime.Now,
                            State = (int)EntityStateEnum.Online,
                        });
                        db.SaveChanges();
                    }

                    VenusPageType VenusEntityListPage = db.VenusPageType.FirstOrDefault(x => x.Title == "VenusEntityListPage");
                    VenusPageType VenusEntityDetailPage = db.VenusPageType.FirstOrDefault(x => x.Title == "VenusEntityDetailPage");
                    VenusEntityDataUrl VenusEntityDataUrl = db.VenusEntityDataUrl.FirstOrDefault(x => x.EntityName == blog.Name);

                    if (!db.VenusPageAbout.Any(x=>x.Name == "BlogList"))
                    {
                        db.VenusPageAbout.Add(new VenusPageAbout()
                        {
                            Id = Guid.NewGuid(),
                            Name = "BlogList",
                            Controller = "BlogController",
                            Action = "List",
                            CreateDate= DateTime.Now,
                            Description = "BLog Liste sayfası",
                            State = (int)EntityStateEnum.Online,
                            PageTypeId = VenusEntityListPage.Id,
                            EntityDataUrl = VenusEntityDataUrl,
                        });
                        db.SaveChanges();
                    }

                    if (!db.VenusPageAbout.Any(x => x.Name == "BlogDetail"))
                    {
                        db.VenusPageAbout.Add(new VenusPageAbout()
                        {
                            Id = Guid.NewGuid(),
                            Name = "BlogDetail",
                            Controller = "BlogController",
                            Action = "Detail",
                            CreateDate = DateTime.Now,
                            Description = "BLog detay sayfası",
                            State = (int)EntityStateEnum.Online,
                            PageTypeId = VenusEntityDetailPage.Id,
                            EntityDataUrl = VenusEntityDataUrl,
                        });
                        db.SaveChanges();
                    }

                    VenusPageAbout BlogDetailAbout = db.VenusPageAbout.FirstOrDefault(x => x.Name == "BlogDetail");
                    VenusPageAbout BlogListAbout = db.VenusPageAbout.FirstOrDefault(x => x.Name == "BlogList");

                    if (!db.VenusUrl.Any(x=>x.PageTypeId == VenusEntityListPage.Id))
                    {
                        db.VenusUrl.Add(new VenusUrl()
                        {
                            Id = Guid.NewGuid(),
                            CreateDate = DateTime.Now,
                            FullPath = "/blog",
                            Path = "/blog",
                            UrlType = (short)UrlTypeEnum.List,
                            PageTypeId = VenusEntityListPage.Id,
                            State = (int)EntityStateEnum.Online,
                            LanguageId = language.Id,
                            Pages = new List<VenusPage>()
                            {
                                new VenusPage()
                                {
                                    Id = Guid.NewGuid(),
                                    LanguageId = language.Id,
                                    CreateDate= DateTime.Now,
                                    State = (int)EntityStateEnum.Online,
                                    Description = "Blog list sayfası",
                                    Name = "Bloglar",
                                    PageAboutId = BlogListAbout.Id,
                                    SubPages = new List<VenusPage>()
                                    {
                                        new VenusPage()
                                        {
                                            Id = Guid.NewGuid(),
                                            PageAboutId = BlogDetailAbout.Id,
                                            Name = "Blog Detay",
                                            CreateDate = DateTime.Now,
                                            State = (int)EntityStateEnum.Online,
                                            Description = "Blog Detay",
                                            LanguageId = language.Id,
                                            Url = new VenusUrl()
                                            {
                                                Id = Guid.NewGuid(),
                                                CreateDate = DateTime.Now,
                                                FullPath = "/blog",
                                                UrlType = (short)UrlTypeEnum.Detail,
                                                Path = "/blog",
                                                PageTypeId = VenusEntityDetailPage.Id,
                                                State = (int)EntityStateEnum.Online,
                                                LanguageId = language.Id,
                                            }
                                        }
                                    }
                                }
                            }
                        });
                        db.SaveChanges();
                    }


                    VenusUrl blogBaseUrl = db.VenusUrl.Where(x => x.UrlType == (short)UrlTypeEnum.Detail && x.PageType.PageAbout.EntityDataUrl.EntityName == nameof(Blog)).FirstOrDefault();

                    db.Blog.Add(new Blog()
                    {
                        Url = new VenusUrl()
                        {
                            Id = Guid.NewGuid(),
                            FullPath = $"{blogBaseUrl.FullPath}/test-blog",
                            Path = "/test-blog",
                            UrlType = (short)UrlTypeEnum.Entity,
                            LanguageId = language.Id,
                            State = (int)EntityStateEnum.Online,
                            PageTypeId = VenusEntityDetailPage.Id,
                            CreateDate = DateTime.Now,
                            ModifiedDate = null,
                            ParentUrlId = blogBaseUrl.Id,
                        },
                        CreateDate = DateTime.Now,
                        Description = "Test blog içeriği",
                        Id = Guid.NewGuid(),
                        State = (int)EntityStateEnum.Online,
                        ModifiedDate = null,
                        Title = "test-blog",

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
