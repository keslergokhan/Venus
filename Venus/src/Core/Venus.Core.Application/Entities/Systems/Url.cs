using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Entities.Base;
using Venus.Core.Application.Entities.Interfaces;

namespace Venus.Core.Application.Entities.Systems
{
    public partial class Url : EntityBase, IEntity
    {
        public string Path { get; set; }
        public string FullPath { get; set; }
        public bool IsEntity { get; set; }

        public Guid? ParentUrlId { get; set; }
        public Url ParentUrl { get; set; }
    }

    public partial class Url : IEntityLanguage
    {
        public Guid LanguageId { get; set; }
        public Language Language { get; set; }
    }

    public partial class Url
    {
        public ICollection<Url> SubUrls { get; set; }
        public PageType PageType { get; set; }
        public Guid PageTypeId { get; set; }
    }
}
}
