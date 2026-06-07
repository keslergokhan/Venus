using HtmlAgilityPack;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Venus.Presentation.Client.Core.HtmlCustomTagHelpers;
using Venus.Presentation.Client.Core.HtmlCustomTagHelpers.Base;

namespace Venus.Presentation.Client.Core.HtmlCustomTagParser
{

    

    public class HtmlCustomTagParserAndRenderFactory : IHtmlCustomTagParserAndRenderFactory
    {
        private readonly IEnumerable<IVenusHtmlCustomTagHelper> _venusHtmlCustomTagHelpers;

        public HtmlCustomTagParserAndRenderFactory(IEnumerable<IVenusHtmlCustomTagHelper> venusHtmlCustomTagHelpers)
        {
            _venusHtmlCustomTagHelpers = venusHtmlCustomTagHelpers;
        }


        public async Task<string> ParserAsync(string html)
        {
            var htmlDocument = new HtmlDocument();

            htmlDocument.LoadHtml(html);

            foreach (IVenusHtmlCustomTagHelper tagHelper in _venusHtmlCustomTagHelpers)
            {

                HtmlCustomTagIterator iterator = new HtmlCustomTagIterator(htmlDocument, tagHelper);

                while (iterator.HasNext())
                {
                    var htmlNode = iterator.Next();
                    await tagHelper.RenderTemplateAsync(htmlNode);
                }
            }

            return htmlDocument.DocumentNode.OuterHtml;
        }
    }
}
