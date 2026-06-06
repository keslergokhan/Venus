using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.PageZone;
using Venus.Presentation.Client.Core.HtmlCustomTagHelpers;

namespace Venus.Presentation.Client.Core.HtmlCustomTagParser
{
    public class HtmlCustomTagRenderFactory : IHtmlCustomTagRenderFactory
    {
        private readonly IHtmlCustomTagParserFactory _htmlCustomTagParserFactory;
        private readonly IServiceProvider _serviceProvider;

        public HtmlCustomTagRenderFactory(IHtmlCustomTagParserFactory htmlCustomTagParserFactory, IServiceProvider serviceProvider)
        {
            _htmlCustomTagParserFactory = htmlCustomTagParserFactory;
            _serviceProvider = serviceProvider;
        }



        public async Task<string> ZoneRenderWidgetAsync(ReadVenusPageZoneDto pageZone)
        {
            VenusWidgetHtmlCustomTagHelper widgetTagHelper = new VenusWidgetHtmlCustomTagHelper(_serviceProvider);

            foreach (ReadVenusPageZoneWidgetDto pageZoneWidget in pageZone.ZoneWidgets)
            {
            }
            return null;
        }
    }
}
