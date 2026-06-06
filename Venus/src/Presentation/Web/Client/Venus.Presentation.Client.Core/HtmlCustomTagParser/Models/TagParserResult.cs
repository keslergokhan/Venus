using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Presentation.Client.Core.HtmlCustomTagHelpers;

namespace Venus.Presentation.Client.Core.HtmlCustomTagParser
{
    public class TagParserResult
    {
        public List<TagParserItem> ParserItems { get; set; }
        public HtmlDocument HtmlDocument { get; set; }
    }

    public class TagParserItem
    {
        public HtmlNodeCollection TagCollection { get; set; }
        public IVenusHtmlCustomTagHelper CustomTagHelper { get; set; }
    }
}
