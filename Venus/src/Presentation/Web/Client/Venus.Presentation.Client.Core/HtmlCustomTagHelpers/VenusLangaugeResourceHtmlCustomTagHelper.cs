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
        public VenusLangaugeResourceHtmlCustomTagHelper(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public override string HtmlTargetElement => "venus-lan-resource";

       

        protected override async Task<string> GetTemplateAsync()
        {
            return "<span>{{Model.message}}</span>";
        }

        
    }
}
