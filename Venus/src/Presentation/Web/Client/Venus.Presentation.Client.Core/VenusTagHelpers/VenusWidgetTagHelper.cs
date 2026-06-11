using MediatR;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Scriban;
using Scriban.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Widget;
using Venus.Core.Application.Exceptions.Systems;
using Venus.Core.Application.Features.Systems.Widget.Queries;
using Venus.Core.Application.HttpRequests.Interfaces;
using Venus.Core.Application.Results.Interfaces;
using Venus.Presentation.Client.Core.VenusTagHelpers.Base;

namespace Venus.Presentation.Client.Core.VenusTagHelpers
{
    [HtmlTargetElement("venus-widget")]
    public class VenusWidgetTagHelper : VenusTagHelperBase
    {
        public VenusWidgetTagHelper(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            if (string.IsNullOrEmpty(JsonData))
            {
                JsonData = "{}";
            }
        }

        [HtmlAttributeName("key-data")]
        public string Key { get; set; }

        [HtmlAttributeName("json-data")]
        public string JsonData { get; set; }


        public override Dictionary<string, object> GetData()
        {
            return JsonSerializer.Deserialize<Dictionary<string, object>>(JsonData);
        }


        protected override async Task<string> GetTemplateAsync()
        {
            IResultDataControl<ReadVenusWidgetDto> result = await Mediator.Send(new GetVenusWidgetByKeyQuery()
            {
                Key = Key
            });

            return result.Data.Template;
        }

        public override async Task RenderBeforeAsync(TagHelperContext context, TagHelperOutput output, TemplateContext templateContext)
        {
            string sdf = "fff";
        }
    }
}
