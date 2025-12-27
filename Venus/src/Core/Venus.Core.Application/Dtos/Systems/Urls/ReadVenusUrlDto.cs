using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Base;
using Venus.Core.Application.Dtos.Interfaces;
using Venus.Core.Application.Dtos.Systems.Languages;
using Venus.Core.Application.Dtos.Systems.Pages;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Dtos.Systems.Urls
{
    public class ReadVenusUrlDto : ReadVenusDtoBase, IVenusEntityLanguageDto
    {
        public string Path { get; set; }
        public string FullPath { get; set; }
        public bool IsEntity { get; set; }

        public Guid? ParentUrlId { get; set; }
        public ReadVenusUrlDto ParentUrl { get; set; }
        public Guid LanguageId { get; set; }
        public ReadVenusLanguageDto Language {get;set;}
        public List<ReadVenusUrlDto> SubUrls { get; set; }
        public ReadVenusPageTypeDto PageType { get; set; }
        public Guid PageTypeId { get; set; }
        public short UrlType { get; set; }

        public List<ReadVenusPageDto> Pages { get; set; }
    }
}
