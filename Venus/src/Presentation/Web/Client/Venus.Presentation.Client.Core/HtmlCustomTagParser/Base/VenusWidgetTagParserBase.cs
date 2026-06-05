using HtmlAgilityPack;
using MediatR;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.DependencyInjection;
using Scriban;
using Scriban.Parsing;
using Scriban.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using Venus.Core.Application.Dtos.Systems.Widget;
using Venus.Core.Application.Exceptions.Base;
using Venus.Core.Application.Features.Systems.Widget.Queries;
using Venus.Core.Application.HttpRequests.Interfaces;
using Venus.Core.Application.Results.Interfaces;

namespace Venus.Presentation.Client.Core.HtmlCustomTagParser.Base
{
    public abstract class VenusWidgetTagParserBase
    {
        [HtmlAttributeName("key-data")]
        public string Key { get; set; }
        public string JsonData { get; set; }

        protected readonly IMediator Mediator;
        protected readonly IVenusHttpContext VenusHttpContext;
        private readonly IServiceProvider _serviceProvider;

        public string HtmlTargetElement { get; }

        protected VenusWidgetTagParserBase(string htmlTargetElement, IServiceProvider serviceProvider)
        {
            HtmlTargetElement = htmlTargetElement;
            _serviceProvider = serviceProvider;
            Mediator = _serviceProvider.GetRequiredService<IMediator>();
            VenusHttpContext = _serviceProvider.GetRequiredService<IVenusHttpContext>();
        }

        public Dictionary<string, object> GetData()
        {
            return JsonSerializer.Deserialize<Dictionary<string, object>>(JsonData);
        }

        public virtual TemplateContext TemplateContext()
        {
            var context = new TemplateContext();
            var model = GetData();
            var dataJson = JsonSerializer.Serialize(new { Context = VenusHttpContext, Model = model });
            var dataObject = JsonSerializer.Deserialize<Dictionary<string, object>>(dataJson);
            context.PushGlobal(ScriptObject.From(dataObject));
            return context;
        }

        public abstract Task<string> ExecuteAsync(TemplateContext templateContext, HtmlDocument htmlDocument, ReadVenusWidgetDto widget);


        public async Task ErrorRender(HtmlDocument htmlDocument, string errorCode, string errorMessage)
        {
            var widget = HtmlNode.CreateNode($"<{HtmlTargetElement} key-data=\"{Key}\" error-data=\"{errorCode}\" error-message=\"{errorMessage}\"></{HtmlTargetElement}>");
            var script = HtmlNode.CreateNode("<script></script>");
            script.SetAttributeValue("type", "application/json");
            script.InnerHtml = JsonData;
            widget.AppendChild(script);
            htmlDocument.DocumentNode.AppendChild(widget);
        }

        public async Task ParseAsync(string htmlContent)
        {
            var htmlDocument = new HtmlDocument();
            try
            {
                string html = @"
                <div>
                    <venus-widget key-data=""Deneme.Sablonu"" >
                        <script type=""application/json"">
                        {
                            ""deneme"": ""O'Connor"",
                            ""items"": [1,2,3]
                        }
                        </script>
                    </venus-widget>
                    <venus-widget key-data=""Description"" json-data=""tr-TR""></venus-widget>
                </div>";


                Type type = this.GetType();
                var properties = type.GetProperties().Select(x => new
                {
                    Property = x,
                    Attribute = x.GetCustomAttribute<HtmlAttributeNameAttribute>()
                }).Where(x => x.Attribute != null).ToArray();

                htmlDocument.LoadHtml(html);
                var widgets = htmlDocument.DocumentNode.SelectNodes($"//{HtmlTargetElement}");

                if (widgets == null)
                    return;


                foreach (var widget in widgets)
                {
                    foreach (var property in properties)
                    {
                        string attrName = property.Attribute.Name;
                        string attrValue = widget.GetAttributeValue(attrName, "{}");

                        if (attrValue != null)
                        {
                            property.Property.SetValue(this, attrValue);
                        }
                    }

                    var script = widget.SelectSingleNode(".//script[@type='application/json']");
                    JsonData = script?.InnerText ?? "{}";

                    IResultDataControl<ReadVenusWidgetDto> result = await Mediator.Send(new GetVenusWidgetByKeyQuery()
                    {
                        Key = Key,
                        LanguageId = VenusHttpContext.Language.Id
                    });

                    if (!result.IsSuccess)
                        throw result.Exception;

                    var templateContext = TemplateContext();
                    await ExecuteAsync(templateContext,htmlDocument, result.Data);
                    var templateHtml = Template.Parse(result.Data.Template);
                    var renderedHtml = templateHtml.Render(templateContext);
                    widget.AppendChild(HtmlNode.CreateNode(renderedHtml));
                    var sonHali = htmlDocument.DocumentNode.OuterHtml;
                }
            }
            catch (Exception ex)
            {
                if (ex is VenusExceptionBase venusException)
                {
                    await ErrorRender(htmlDocument, venusException.ErrorCode, venusException.Message);
                }
                else
                {
                    await ErrorRender(htmlDocument,"ERROR", "SYSTEM");
                }
            }

        }
    }
}
