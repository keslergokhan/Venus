using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venus.Presentation.Client.Core.VenusTagHelpers
{
    [HtmlTargetElement("venus-widget")]
    public class VenusLanguageResourceTagHelper : TagHelper
    {
        [HtmlAttributeName("widget-name")]
        public string KeyData { get; set; }

        public override void Process(
            TagHelperContext context,
            TagHelperOutput output)
        {
            // Örnek resource lookup

            output.TagName = null; // etiketi kaldır
            output.Content.SetContent($"Bu bir deneme: {KeyData}");
        }

        
    }
}
