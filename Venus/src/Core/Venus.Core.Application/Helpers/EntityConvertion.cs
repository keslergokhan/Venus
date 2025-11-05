using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Languages;
using Venus.Core.Application.Dtos.Systems.Pages;
using Venus.Core.Application.Dtos.Systems.Urls;
using Venus.Core.Application.Dtos.Systems.Users;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Helpers
{
    public class EntityConvertion
    {
        // Lazy<T> ile Singleton örneği tanımlanıyor
        private static readonly Lazy<EntityConvertion> _instance =
            new Lazy<EntityConvertion>(() => new EntityConvertion());

        // Dışarıdan erişim için Instance özelliği
        public static EntityConvertion Instance => _instance.Value;

        public ReadVenusUrlDto EntityToDto(VenusUrl url)
        {
            if (url == null)
                return null;

            List<ReadVenusPageDto> pages = new List<ReadVenusPageDto>();
            url.Pages?.ToList()?.ForEach(x =>
            {
                if (x!=null)
                {
                    pages.Add(EntityConvertion.Instance.EntityToDto(x));
                }
            });

            url.Pages = null;
            var aa = new ReadVenusUrlDto()
            {
                Id = url.Id,
                FullPath = url.FullPath,
                IsEntity = url.IsEntity,
                LanguageId = url.LanguageId,
                Language = EntityConvertion.Instance.EntityToDto(url.Language),
                PageType = EntityConvertion.Instance.EntityToDto(url.PageType),
                ParentUrlId = url.ParentUrlId,
                Path = url.Path,    
                SubUrls = url.SubUrls?.Select(x=>EntityConvertion.Instance.EntityToDto(x)).ToList(),
                Pages = pages,
                PageTypeId = url.PageTypeId,
                ParentUrl = EntityConvertion.Instance.EntityToDto(url.ParentUrl)
            };

            return aa;
        }

        public ReadVenusPageDto EntityToDto(VenusPage page)
        {
            if (page == null)
                return null;

            bool urlControl = object.ReferenceEquals(page, page.Url.Pages.FirstOrDefault());

            var url = new ReadVenusUrlDto()
            {
                Id = page.Url.Id,
                PageType = EntityConvertion.Instance.EntityToDto(page.Url.PageType),
                IsEntity = page.Url.IsEntity,
                Path = page.Url.Path,
                FullPath= page.Url.FullPath,    
                LanguageId= page.Url.LanguageId,
                ParentUrlId= page.Url.ParentUrlId,
                Pages = null,
                ParentUrl = EntityConvertion.Instance.EntityToDto(page.Url.ParentUrl),
                PageTypeId = page.Url.PageTypeId,
                SubUrls = page.Url?.SubUrls?.Select(x=>EntityConvertion.Instance.EntityToDto(x)).ToList()
            };

            return new ReadVenusPageDto()
            {
                Id = page.Id,
                Language = EntityConvertion.Instance.EntityToDto(page.Language),
                LanguageId = page.LanguageId,
                Name = page.Name,
                Description = page.Description,
                PageAbout = EntityConvertion.Instance.EntityToDto(page.PageAbout),
                PageAboutId = page.PageAboutId,
                ParentPageId = page.ParentPageId,
                Url = url,
                UrlId = page.UrlId,
                ParentPage = EntityConvertion.Instance.EntityToDto(page.ParentPage),
                SubPages =  page.SubPages?.Select(x=>EntityConvertion.Instance.EntityToDto(x)).ToList()
            };
        }


        public ReadVenusPageTypeDto EntityToDto(VenusPageType type)
        {
            if (type == null)
                return null;

            return new ReadVenusPageTypeDto()
            {
                Description = type.Description,
                Id = type.Id,
                InterfaceClassType = type.InterfaceClassType,
                PageAbouts = type.PageAbouts?.Select(x=>EntityConvertion.Instance.EntityToDto(x)).ToList(),
                Title = type.Title
            };
        }

        public ReadVenusLanguageDto EntityToDto(VenusLanguage language)
        {
            if (language == null)
                return null;

            return new ReadVenusLanguageDto()
            {
                CountryCode = language.CountryCode,
                Culture = language.Culture,
                Currency = language.Currency,
                Id = language.Id,
                Name = language.Name,
                Sort = language.Sort
            };
        }

        public ReadVenusPageAboutDto EntityToDto(VenusPageAbout about)
        {
            if (about == null)
                return null;

            return new ReadVenusPageAboutDto()
            {
                Action = about.Action,
                Controller = about.Controller,
                Name = about.Name,  
                Id = about.Id,
                Description = about.Description,    
                IsEntity = about.IsEntity,
            };
        }


        public ReadVenusUserDto EntityToDto(VenusUser venusUser)
        {
            if (venusUser == null)
                return null;


            return new ReadVenusUserDto()
            {
                Email = venusUser.Email,
                Name = venusUser.Name,
                Id = venusUser.Id,
                Password = venusUser.Password,
                Surname = venusUser.Surname 
            };
        }

    }
}
