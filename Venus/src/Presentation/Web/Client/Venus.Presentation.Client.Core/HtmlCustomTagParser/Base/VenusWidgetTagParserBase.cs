using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Scriban.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Venus.Presentation.Client.Core.HtmlCustomTagParser.Base
{
    public abstract class VenusWidgetTagParserBase
    {
        [HtmlAttributeName("key-data")]
        public string Key { get; set; }
        public string HtmlTargetElement { get; }

        protected VenusWidgetTagParserBase(string htmlTargetElement)
        {
            HtmlTargetElement = htmlTargetElement;
        }

        public abstract Task<string> ExecuteAsync();


        public async Task<string> ParseAsync(string htmlContent)
        {
            string html = @"
            <div>
                <venus-widget key-data=""Title"" json-data=""bu bir deneme""></venus-widget>
                <venus-widget key-data=""Description"" json-data=""tr-TR""></venus-widget>
            </div>";

            var regex = new Regex(@"<venus-widget[^>]*>.*?</venus-widget>", RegexOptions.Singleline | RegexOptions.IgnoreCase);

            var matches = regex.Matches(html);
            

            foreach (var item in matches)
            {
                var element = XElement.Parse(item.ToString());

                Type type = this.GetType();
                var properties = type.GetProperties();
                string widgetKey = element.Attribute("key-data").Value;

                var attrData = new List<KeyValuePair<string, string>>();
                foreach (var property in properties) {

                    var attr = property.GetCustomAttribute<HtmlAttributeNameAttribute>();
                    if (attr==null || attr.Name == "key-data")
                    {
                        continue;
                    }
                    
                    var attrValue = element.Attribute(attr.Name).Value;

                    type.GetProperty(property.Name).SetValue(this, attrValue);
                }
                var result = await ExecuteAsync();
            }

            return "";
        }
    }
}
