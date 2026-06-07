using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Presentation.Client.Core.HtmlCustomTagHelpers;

namespace Venus.Presentation.Client.Core.HtmlCustomTagParser
{
    public class HtmlCustomTagIterator : HtmlCustomTagIterator<HtmlNode>
    {
        private HtmlNodeCollection _htmlCollection;
        private HtmlDocument _htmlDocument;
        private IVenusHtmlCustomTagHelper _venusHtmlCustomTagHelper;
        private int _count;
        public HtmlCustomTagIterator(HtmlDocument htmlDocument, IVenusHtmlCustomTagHelper venusHtmlCustomTagHelper)
        {
            _htmlDocument = htmlDocument;
            _venusHtmlCustomTagHelper = venusHtmlCustomTagHelper;
            SelectNodes();

            _count = 0;
        }

        private void SelectNodes()
        {
            _htmlCollection = _htmlDocument.DocumentNode.SelectNodes($"//{_venusHtmlCustomTagHelper.HtmlTargetElement}");
        }

        public bool HasNext()
        {
            if (_htmlCollection == null)
                return false;

            var control = _count < _htmlCollection?.Count;

            if (control == false)
            {
                SelectNodes();
                if (_htmlCollection?.Count > 0)
                {
                    Reset();
                    return true;
                }
            }

            return control;
        }

        public HtmlNode Next()
        {
            if (HasNext())
            {
                _count++;
                return _htmlCollection[_count - 1];
            }

            throw new InvalidOperationException();
        }

        public void Reset()
        {
            _count = 0;
        }
    }
}
