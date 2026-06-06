using HtmlAgilityPack;
using MediatR;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using Scriban;
using Scriban.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Xml.Linq;
using Venus.Core.Application.Dtos.Systems.Widget;
using Venus.Core.Application.Exceptions.Base;
using Venus.Core.Application.Features.Systems.Widget.Queries;
using Venus.Core.Application.HttpRequests.Interfaces;
using Venus.Core.Application.Results.Interfaces;

namespace Venus.Presentation.Client.Core.HtmlCustomTagHelpers.Base
{
    public abstract class VenusHtmlCustomTagHelper
    {
        [VenusHtmlCustomTagNameAttribute("json-data","{}")]
        public string JsonData { get; set; }

        protected readonly IMediator Mediator;
        protected readonly IVenusHttpContext VenusHttpContext;
        private readonly IServiceProvider _serviceProvider;

        public abstract string HtmlTargetElement { get; }

        public VenusHtmlCustomTagHelper(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            Mediator = _serviceProvider.GetRequiredService<IMediator>();
            VenusHttpContext = _serviceProvider.GetRequiredService<IVenusHttpContext>();
        }
      
        protected Dictionary<string, object> GetData()
        {
            return JsonSerializer.Deserialize<Dictionary<string, object>>(JsonData);
        }

        protected virtual TemplateContext TemplateContext()
        {
            var context = new TemplateContext();
            var model = GetData();
            var dataJson = JsonSerializer.Serialize(new { Context = VenusHttpContext, Model = model });
            var dataObject = JsonSerializer.Deserialize<Dictionary<string, object>>(dataJson);
            context.PushGlobal(ScriptObject.From(dataObject));
            return context;
        }

        protected virtual Task RenderBeforeAsync(TemplateContext templateContext, Template template)
        {
            return Task.CompletedTask;
        }

        protected virtual Task RenderAfterAsync(string htmlResult)
        {
            return Task.CompletedTask;
        }


        protected abstract Task<string> GetTemplateAsync();

        protected async Task ErrorRender(HtmlNode htmlWidget, string errorCode, string errorMessage)
        {
            var widgetContent = HtmlNode.CreateNode($"<{HtmlTargetElement}-error error-data=\"{errorCode}\" error-message=\"{errorMessage}\"></{HtmlTargetElement}>");
            var script = HtmlNode.CreateNode("<script></script>");
            script.SetAttributeValue("type", "application/json");
            script.InnerHtml = JsonData;
            widgetContent.AppendChild(script);
            htmlWidget.AppendChild(widgetContent);
        }

        protected VenusHtmlCustomTagHelper LoadPropertySetData(HtmlNode cutomTagNode)
        {

            Type type = this.GetType();
            var types = type.GetProperties().Select(x => new
            {
                Property = x,
                Attribute = x.GetCustomAttribute<VenusHtmlCustomTagNameAttribute>()
            }).Where(x => x.Attribute != null).ToArray();

            foreach (var item in types)
            {
                if (cutomTagNode != null)
                {
                    var htmlAttrValue = cutomTagNode.GetAttributeValue<string>(item.Attribute.Name,item.Attribute.DefaultValue);
                    item.Property.SetValue(this,htmlAttrValue);
                }
                else
                {
                    item.Property.SetValue(this, item.Attribute.DefaultValue);
                }
            }

            if (JsonData == null || JsonData=="{}")
            {
                var script = cutomTagNode.SelectSingleNode(".//script[@type='application/json']");
                JsonData = script?.InnerText ?? "{}";
            }

            return this;
        }

        public async Task<string> RenderTemplateAsync(HtmlNode cutomTagNode)
        {
            string html = string.Empty;
            try
            {
                LoadPropertySetData(cutomTagNode);

                var templateContext = TemplateContext();
                string template = await GetTemplateAsync();
                var templateHtml = Template.Parse(template);
                await RenderBeforeAsync(templateContext, templateHtml);
                html = templateHtml.Render(templateContext);
                await RenderAfterAsync(html);
            }
            catch (Exception ex)
            {
                if (ex is VenusExceptionBase venusException)
                {
                    await ErrorRender(cutomTagNode, venusException.ErrorCode, venusException.Message);
                }
                else
                {
                    await ErrorRender(cutomTagNode, "ERROR", "SYSTEM");
                }
            }

            cutomTagNode.AppendChild(HtmlNode.CreateNode(html));
            cutomTagNode.Name = "div";
            cutomTagNode.Attributes.Add("widget-data", HtmlTargetElement);

            return html;
        }

    }
}
