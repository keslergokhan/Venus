using MediatR;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Features.Systems.Page.Queries;
using Venus.Core.Application.HttpRequests.Interfaces;
using Venus.Presentation.Client.Core.HtmlCustomTagParser;

namespace Venus.Presentation.Client.Core.VenusTagHelpers
{
    public class VenusPageZoneTagHelper : TagHelper
    {

        [HtmlAttributeName("key-data")]
        public string Key { get; set; }

        private readonly IMediator _mediator;
        private readonly IVenusHttpContext _venusHttpContext;
        private readonly IHtmlCustomTagParserAndRenderFactory _htmlCustomTagParserAndRenderFactory;

        public VenusPageZoneTagHelper(IMediator mediator, IVenusHttpContext venusHttpContext, IHtmlCustomTagParserAndRenderFactory htmlCustomTagParserAndRenderFactory)
        {
            _mediator = mediator;
            _venusHttpContext = venusHttpContext;
            _htmlCustomTagParserAndRenderFactory = htmlCustomTagParserAndRenderFactory;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            try
            {
                var result = await _mediator.Send(new GetVenusPageZoneAndWidgetsByPageIdAndKeyQuery(){
                    Key = Key,
                    PageId = _venusHttpContext.Page.Id,
                    LanguageId = _venusHttpContext.Language.Id
                });

                if (!result.IsSuccess)
                    throw result.Exception;

                foreach (var widget in result.Data.ZoneWidgets)
                {

                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
