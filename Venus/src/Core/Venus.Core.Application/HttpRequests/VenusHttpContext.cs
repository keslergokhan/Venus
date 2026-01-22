using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Languages;
using Venus.Core.Application.Dtos.Systems.Pages;
using Venus.Core.Application.Dtos.Systems.Urls;
using Venus.Core.Application.Enums.Systems;
using Venus.Core.Application.HttpRequests.Base;
using Venus.Core.Application.HttpRequests.Interfaces;
using Venus.Core.Application.VenusDbContext.Interfaces;

namespace Venus.Core.Application.HttpRequests
{
    public partial class VenusHttpContext : VenusHttpContextBase
    {
      
    }

    public partial class VenusHttpContext
    {
        public class VenusHttpPage
        {
            public Guid Id { get; }

            public VenusHttpPage(ReadVenusPageDto readVenusPageDto,ReadVenusPageAboutDto readVenusPageAboutDto)
            {
                Id = readVenusPageAboutDto.Id;
                Name = readVenusPageDto.Name;
                Description = readVenusPageDto.Description;
                Controller = readVenusPageAboutDto.Controller;
                Action = readVenusPageAboutDto.Action;
                EntityClassType = readVenusPageAboutDto.EntityPage != null ? readVenusPageAboutDto.EntityPage.EntityClassType : string.Empty;
                Entity = readVenusPageAboutDto.EntityPage != null ? readVenusPageAboutDto.EntityPage.EntityName : string.Empty;
            }

            public string Name { get; }
            public string Description { get; }
            public string Controller { get;}
            public string Action { get; }
            public string EntityClassType { get; }
            public string Entity { get; }
        }
        public class VenusHttpLanguage
        {
            public Guid Id { get; }
            public string Name { get; }
            public string CountryCode { get; }
            public string Culture { get; }
            public string Currency { get; }
            public VenusHttpLanguage(ReadVenusLanguageDto readVenusLanguageDto)
            {
                Name = readVenusLanguageDto.Name;
                CountryCode = readVenusLanguageDto.CountryCode;
                Culture = readVenusLanguageDto.Culture;
                Currency = readVenusLanguageDto.Currency;
                Id = readVenusLanguageDto.Id;
            }
        }
        public class VenusHttpUrl
        {
            public bool IsEntity { get; }
            public string Schema { get; }
            public string Host { get; }
            public string Region { get;}
            public string Path { get; }
            public string FullPath { get; }
            public string BaseUrl { get; }
            public Guid Id { get; }
            public Guid? ParentId { get; }
            public short UrlType { get; set; }
            public VenusHttpUrl(
                string fullPath,
                string schema,
                string host,
                string path,
                string baseUrl,ReadVenusUrlDto readVenusUrlDto)
            {
                FullPath = fullPath;
                Schema = schema;
                Host = host;
                Path = path;
                BaseUrl = baseUrl;
                Id = readVenusUrlDto.Id;
                ParentId = readVenusUrlDto.ParentUrlId;
                UrlType = readVenusUrlDto.UrlType;  
            }
        }
        
    }
}
