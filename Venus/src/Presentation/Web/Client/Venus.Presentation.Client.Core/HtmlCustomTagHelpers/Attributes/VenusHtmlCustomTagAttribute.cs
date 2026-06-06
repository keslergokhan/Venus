using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venus.Presentation.Client.Core.HtmlCustomTagHelpers
{
    public class VenusHtmlCustomTagNameAttribute : Attribute
    {
        public string Name { get; set; }
        public string DefaultValue { get; set; }

        public VenusHtmlCustomTagNameAttribute(string name,string defaultValue)
        {
            Name = name;
            DefaultValue = defaultValue;
        }
    }
}
