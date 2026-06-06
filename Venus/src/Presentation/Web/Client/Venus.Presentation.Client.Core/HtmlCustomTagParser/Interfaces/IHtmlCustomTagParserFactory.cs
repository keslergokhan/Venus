using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venus.Presentation.Client.Core.HtmlCustomTagParser
{
    public interface IHtmlCustomTagParserFactory
    {
        public TagParserResult ParserAsync(string html);
    }
}
