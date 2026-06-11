using Scriban;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Widget;
using Venus.Presentation.Client.Core.HtmlCustomTagHelpers.Base;

namespace Venus.Presentation.Client.Core.HtmlCustomTagHelpers
{
    public class VenusLangaugeResourceHtmlCustomTagHelper : VenusHtmlCustomTagHelper, IVenusHtmlCustomTagHelper
    {
        [VenusHtmlCustomTagNameAttribute("key-data", "")]
        public string Key { get; set; }
        public VenusLangaugeResourceHtmlCustomTagHelper(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public override string HtmlTargetElement => "venus-lan-resource";

        public override short RenderOrder => 99;

        protected override async Task<string> GetTemplateAsync()
        {
            return $"<span>{Key}</span>";
        }

        
    }
}
