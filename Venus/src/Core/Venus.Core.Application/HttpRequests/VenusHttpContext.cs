using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            public VenusHttpPage(Guid ıd, string name, string description, string controller, string action)
            {
                Id = ıd;
                Name = name;
                Description = description;
                Controller = controller;
                Action = action;
            }

            public string Name { get; }
            public string Description { get; }
            public string Controller { get;}
            public string Action { get; }
            public bool IsEntity { get; set; }
        }


        public class VenusHttpLanguage
        {
            public Guid Id { get; }
            public string Name { get; }
            public string CountryCode { get; }
            public string Culture { get; }
            public string Currency { get; }
            public VenusHttpLanguage(string name, string countryCode, string culture, string currency, Guid id)
            {
                Name = name;
                CountryCode = countryCode;
                Culture = culture;
                Currency = currency;
                Id = id;
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
            public Guid? ParentUrlId { get; }
            public VenusHttpUrl(Guid id,
                string fullPath,
                string schema,
                string host,
                string path,
                string baseUrl,
                Guid? parentUrlId,
                bool ısEntity)
            {
                Id = id;
                FullPath = fullPath;
                Schema = schema;
                Host = host;
                Path = path;
                BaseUrl = baseUrl;
                ParentUrlId = parentUrlId;
                IsEntity = ısEntity;
            }
        }
    }
}
