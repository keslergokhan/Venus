using MediatR;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Scriban;
using Scriban.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Widget;
using Venus.Core.Application.HttpRequests.Interfaces;
using Venus.Presentation.Client.Core.VenusTagHelpers.Base;

namespace Venus.Presentation.Client.Core.VenusTagHelpers
{
    [HtmlTargetElement("venus-widget")]
    public class VenusWidgetTagHelper : VenusTagHelperBase
    {
        public VenusWidgetTagHelper(IVenusHttpContext venusHttpContext, IMediator mediator) : base(venusHttpContext, mediator)
        {
        }

        public override Task ExecuteAsync(TagHelperContext context, TagHelperOutput output, TemplateContext templateContext, ReadVenusWidgetDto widget)
        {


            return Task.FromResult(true);
        }
    }
}
