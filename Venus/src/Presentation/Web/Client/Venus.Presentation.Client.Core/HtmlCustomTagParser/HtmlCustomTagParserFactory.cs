using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Presentation.Client.Core.HtmlCustomTagHelpers;

namespace Venus.Presentation.Client.Core.HtmlCustomTagParser
{
    public class HtmlCustomTagParserFactory : IHtmlCustomTagParserFactory
    {
        private readonly IEnumerable<IVenusHtmlCustomTagHelper> _venusHtmlCustomTagHelpers;

        public HtmlCustomTagParserFactory(IEnumerable<IVenusHtmlCustomTagHelper> venusHtmlCustomTagHelpers)
        {
            _venusHtmlCustomTagHelpers = venusHtmlCustomTagHelpers;
        }


        public TagParserResult ParserAsync(string html)
        {
            TagParserResult model = new TagParserResult();
             html = @"
                <div>
                    <venus-widget key-data=""Deneme.Sablonu"" >
                        <script type=""application/json"">
                        {
                            ""deneme"": ""O'Connor"",
                            ""items"": [1,2,3]
                        }
                        </script>
                    </venus-widget>
                </div>";

            var htmlDocument = new HtmlDocument();

            htmlDocument.LoadHtml(html);
            model.HtmlDocument = htmlDocument;


            foreach (IVenusHtmlCustomTagHelper tagHelper in _venusHtmlCustomTagHelpers)
            {
                var customTags = htmlDocument.DocumentNode.SelectNodes($"//{tagHelper.HtmlTargetElement}");
                model.ParserItems.Add(new TagParserItem()
                {
                    CustomTagHelper = tagHelper,
                    TagCollection = customTags
                });
            }

            return model;
        }
    }
}
