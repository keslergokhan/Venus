using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Presentation.Client.Core.HtmlCustomTagParser.Base;

namespace Venus.Presentation.Client.Core.HtmlCustomTagParser
{
    public class VenusWidgetTagParser : VenusWidgetTagParserBase
    {

        [HtmlAttributeName("json-data")]
        public string JsonData { get; set; }
        public VenusWidgetTagParser() : base("venus-widget")
        {
        }

        public override async Task<string> ExecuteAsync()
        {
            var sss = JsonData;
            return sss;
        }
    }
}
