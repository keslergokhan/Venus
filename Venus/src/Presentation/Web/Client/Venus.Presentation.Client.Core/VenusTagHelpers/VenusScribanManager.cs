using Microsoft.AspNetCore.Razor.TagHelpers;
using Scriban;
using Scriban.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Venus.Core.Application.HttpRequests;
using Venus.Core.Application.HttpRequests.Interfaces;
using Venus.Presentation.Client.Core.HtmlCustomTagParser;
using Venus.Presentation.Client.Core.VenusTagHelpers.Base;

namespace Venus.Presentation.Client.Core.VenusTagHelpers
{
    public class VenusScribanManager : VenusWidgetManagerBase, IVenusScribanManager
    {
        public VenusScribanManager(IHtmlCustomTagParserAndRenderFactory htmlCustomTagParserAndRenderFactory, IVenusHttpContext venusHttpContext) : base(htmlCustomTagParserAndRenderFactory, venusHttpContext)
        {
        }
    }
}
