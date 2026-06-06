using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venus.Presentation.Client.Core.HtmlCustomTagHelpers
{
    public interface IVenusHtmlCustomTagHelper
    {
        public abstract string HtmlTargetElement { get; }
        public Task<string> RenderTemplateAsync(HtmlNode cutomTagNode);
    }
}
