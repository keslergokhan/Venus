using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Base;
using Venus.Core.Application.Dtos.Systems.Urls;

namespace Venus.Core.Application.Dtos.Entities.Blogs
{
    public class ReadBlogDto : ReadVenusDtoBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string JsonData { get; set; }
        public string UrlPath { get; set; }
        public ReadVenusUrlDto Url { get; set; }
    }

    public class ReadBlogDynamicData
    {
        public string Category { get; set; }
    }
}
