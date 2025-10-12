using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Entities.Base;
using Venus.Core.Application.Entities.Interfaces;

namespace Venus.Core.Application.Entities.Systems
{
    public partial class Page :EntityBase, IEntity, IUrlEntity
    {
        public string Name { get; set; }
        public Url Url { get; set; }
        public Guid UrlId { get; set; }
    }

    public partial class Page : IEntityLanguage
    {
        public Guid LanguageId { get; set; }
        public Language Language { get; set; }
    }

    public partial class Page
    {
        public Guid PageTypeId { get; set; }
        public PageType PageType { get; set; }


        public Guid? ParentPageId { get; set; }
        public Page ParentPage { get; set; }

    }
}
