using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Domain.Entities.Base;
using Venus.Core.Domain.Entities.Interfaces;

namespace Venus.Core.Domain.Entities.Systems
{
    public partial class VenusPage :VenusEntityBase, IVenusEntity, IVenusUrlEntity
    {
        public string Name { get; set; }
        public VenusUrl Url { get; set; }
        public Guid UrlId { get; set; }
    }

    public partial class VenusPage : IVenusEntityLanguage
    {
        public Guid LanguageId { get; set; }
        public VenusLanguage Language { get; set; }
    }

    public partial class VenusPage
    {
        public Guid PageAboutId { get; set; }
        public VenusPageAbout PageAbout { get; set; }


        public Guid? ParentPageId { get; set; }
        public VenusPage ParentPage { get; set; }

        public ICollection<VenusPage> SubPages { get; set; }
    }
}
