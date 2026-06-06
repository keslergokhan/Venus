using HtmlAgilityPack;
using MediatR;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Scriban;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Widget;
using Venus.Core.Application.HttpRequests.Interfaces;
using Venus.Presentation.Client.Core.HtmlCustomTagParser.Base;

namespace Venus.Presentation.Client.Core.HtmlCustomTagParser
{
    public class VenusWidgetTagParser : VenusWidgetTagParserBase
    {

        public VenusWidgetTagParser(IServiceProvider serviceProvider) : base("venus-widget", serviceProvider)
        {
        }

        public override async Task<string> ExecuteAsync(TemplateContext templateContext, HtmlNode htmlWidget, ReadVenusWidgetDto widget)
        {
            var sss = JsonData;
            return sss;
        }
    }
}
