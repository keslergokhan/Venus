using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Domain.Entities.Base;
using Venus.Core.Domain.Entities.Interfaces;

namespace Venus.Core.Domain.Entities.Systems
{
    public partial class VenusUrl : VenusEntityBase
    {
        public string Path { get; set; }
        public string FullPath { get; set; }
        public short UrlType { get;set; }

        public Guid? ParentUrlId { get; set; }
        public VenusUrl ParentUrl { get; set; }
    }

    public partial class VenusUrl : IVenusEntityLanguage
    {
        public Guid LanguageId { get; set; }
        public VenusLanguage Language { get; set; }
    }

    public partial class VenusUrl
    {
        public ICollection<VenusUrl> SubUrls { get; set; }
        public VenusPageType PageType { get; set; }
        public Guid PageTypeId { get; set; }

        public ICollection<VenusPage> Pages { get; set; }
    }
}
