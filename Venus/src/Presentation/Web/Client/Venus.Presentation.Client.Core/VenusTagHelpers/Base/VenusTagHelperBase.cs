using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Scriban;
using Scriban.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Widget;
using Venus.Core.Application.Exceptions.Base;
using Venus.Core.Application.Exceptions.Systems;
using Venus.Core.Application.Features.Systems.Widget.Queries;
using Venus.Core.Application.HttpRequests.Interfaces;
using Venus.Core.Application.Results.Interfaces;

namespace Venus.Presentation.Client.Core.VenusTagHelpers.Base
{
    public abstract class VenusTagHelperBase : TagHelper
    {
        protected readonly IMediator Mediator;
        protected readonly IVenusHttpContext VenusHttpContext;

        [HtmlAttributeName("json-data")]
        public string JsonData { get; set; }
        [HtmlAttributeName("key-data")]
        public string Key { get; set; }

        public VenusTagHelperBase(IVenusHttpContext venusHttpContext, IMediator mediator)
        {
            VenusHttpContext = venusHttpContext;
            if (string.IsNullOrEmpty(JsonData))
            {
                JsonData = "{}";
            }

            Mediator = mediator;
        }

        public Dictionary<string, object> GetData()
        {
            return JsonSerializer.Deserialize<Dictionary<string, object>>(JsonData);
        }

        public virtual TemplateContext TemplateContext()
        {
            var context = new TemplateContext();

            var dataJson = JsonSerializer.Serialize(new { Context = VenusHttpContext, Model = GetData() });
            var dataObject = JsonSerializer.Deserialize<Dictionary<string, object>>(dataJson);
            context.PushGlobal(ScriptObject.From(dataObject));
            return context;
        }

        public abstract Task ExecuteAsync(TagHelperContext context, TagHelperOutput output,TemplateContext templateContext, ReadVenusWidgetDto widget);

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            try
            {
                IResultDataControl<ReadVenusWidgetDto> result = await Mediator.Send(new GetVenusWidgetByKeyQuery()
                {
                    Key = Key,
                    LanguageId = VenusHttpContext.Language.Id
                });

                if (!result.IsSuccess)
                    throw result.Exception;

                var templateContext = TemplateContext();
                await ExecuteAsync(context, output, templateContext, result.Data);
                var templateHtml = Template.Parse(result.Data.Template);
                var renderedHtml = templateHtml.Render(templateContext);
                output.Content.SetHtmlContent(renderedHtml);
            }
            catch (Exception ex)
            {
                if (ex is VenusExceptionBase venusException)
                {
                    await ErrorProcessAsync(context, output, venusException.ErrorCode, venusException.Message);
                }
                else
                {
                    await ErrorProcessAsync(context, output, "ERROR", "SYSTEM");
                }
            }
        }


        public async Task ErrorProcessAsync(TagHelperContext context, TagHelperOutput output, string errorCode,string errorMessage)
        {
            var container = new TagBuilder("venus-widget-result");
            container.Attributes.Add("error-data", errorCode);
            container.Attributes.Add("error-message", errorMessage);
            output.Content.SetHtmlContent(container);
        }
    }
}
