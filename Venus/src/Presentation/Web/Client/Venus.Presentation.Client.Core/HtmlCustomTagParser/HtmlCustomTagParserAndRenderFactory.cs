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
    /// <summary>
    /// İç içe özel etiketlerin render edilmesini sağlar
    /// </summary>
    /// <remarks>
    /// <para><see cref="IVenusHtmlCustomTagHelper"/> impemente etmiş olan servisler ile html kaynağını okur.</para>
    /// <para>Html kaynağını <see cref="HtmlCustomTagIterator"/> ile gezer ve özel etiketlerin oluşturulmasını sağlar, yeni oluşturulan html kaynaklarını tekrar kontrol eder ve iç içe tanımlanmış özel etiketlerin yakalanmasını ve oluşturulmasını sağlar. </para>
    /// </remarks>
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

            foreach (IVenusHtmlCustomTagHelper tagHelper in _venusHtmlCustomTagHelpers.OrderBy(x=>x.RenderOrder).ToArray())
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
