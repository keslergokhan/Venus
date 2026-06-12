using HtmlAgilityPack;
using MediatR;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.DependencyInjection;
using Scriban;
using Scriban.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Venus.Core.Application.Exceptions.Base;
using Venus.Core.Application.Features.Systems.Page.Queries;
using Venus.Core.Application.HttpRequests.Interfaces;

namespace Venus.Presentation.Client.Core.VenusTagHelpers
{
    public class VenusPageZoneTagHelper : TagHelper
    {
        [HtmlAttributeName("key-data")]
        public string Key { get; set; }

        protected readonly IMediator Mediator;
        protected readonly IVenusHttpContext VenusHttpContext;
        protected readonly IVenusScribanManager VenusWidgetManager;
        protected IServiceProvider ServiceProvider;

        public VenusPageZoneTagHelper(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            Mediator = ServiceProvider.GetRequiredService<IMediator>();
            VenusHttpContext = ServiceProvider.GetRequiredService<IVenusHttpContext>();
            VenusWidgetManager = ServiceProvider.GetRequiredService<IVenusScribanManager>();
        }


        public async Task ErrorProcessAsync(TagHelperContext context, TagHelperOutput output, string errorCode, string errorMessage)
        {
            var container = new TagBuilder("zone-error");
            container.Attributes.Add("error-data", errorCode);
            container.Attributes.Add("error-message", errorMessage);
            output.Content.SetHtmlContent(container);
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {

            try
            {
                var result = await Mediator.Send(new GetVenusPageZoneAndWidgetsByPageIdAndKeyQuery()
                {
                    Key = Key,
                    PageId = VenusHttpContext.Page.Id,
                    LanguageId = VenusHttpContext.Language.Id
                });

                var htmlDocument = new HtmlDocument();
                var zoneDiv = HtmlNode.CreateNode($"<div zone-key-data='{Key}'></div>");

                foreach (var zoneWidget in result.Data.ZoneWidgets)
                {
                    var renderHtmlResult = await VenusWidgetManager.ExecuteAsync(zoneWidget.Widget.Template,zoneWidget.WidgetData,zoneWidget.Widget.WidgetType);
                    if (!string.IsNullOrEmpty(renderHtmlResult))
                    {
                        var widget = HtmlNode.CreateNode(renderHtmlResult);
                        widget.Attributes.Add("key-data", Key);
                        zoneDiv.AppendChild(widget);
                    }
                }

                htmlDocument.DocumentNode.AppendChild(zoneDiv);
                output.Content.SetHtmlContent(htmlDocument.DocumentNode.OuterHtml);
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
    }
}
