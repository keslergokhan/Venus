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

            public VenusHttpPage(Guid id,string name, string description, string controller, string action, string entity, PageTypeEnum pageType, string entityClassType)
            {
                Name = name;
                Description = description;
                Controller = controller;
                Action = action;
                Entity = entity;
                PageType = pageType;
                EntityClassType = entityClassType;
                Id = id;
            }

            public string Name { get; }
            public string Description { get; }
            public string Controller { get;}
            public string Action { get; }
            public string EntityClassType { get; }
            public string Entity { get; }
            public PageTypeEnum PageType { get; }
        }
        public class VenusHttpLanguage
        {
            public Guid Id { get; }
            public string Name { get; }
            public string CountryCode { get; }
            public string Culture { get; }
            public string Currency { get; }
            public VenusHttpLanguage(Guid id, string name, string countryCode, string culture, string currency)
            {
                Id = id;
                Name = name;
                CountryCode = countryCode;
                Culture = culture;
                Currency = currency;
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
            public VenusHttpUrl(Guid id, string path, string fullPath, string baseUrl, string schema, string host, string region, Guid? parentId, bool ısEntity)
            {
                Id = id;
                Path = path;
                FullPath = fullPath;
                BaseUrl = baseUrl;
                Schema = schema;
                Host = host;
                Region = region;
                ParentId = parentId;
                IsEntity = ısEntity;
            }
        }
        
    }
}
