using MediatR;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Features.Systems.Page.Queries;
using Venus.Core.Application.HttpRequests.Interfaces;

namespace Venus.Presentation.Client.Core.VenusTagHelpers
{
    public class VenusPageZoneTagHelper : TagHelper
    {

        [HtmlAttributeName("key-data")]
        public string Key { get; set; }

        private readonly IMediator _mediator;
        private readonly IVenusHttpContext _venusHttpContext;

        public VenusPageZoneTagHelper(IMediator mediator, IVenusHttpContext venusHttpContext)
        {
            _mediator = mediator;
            _venusHttpContext = venusHttpContext;
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

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
