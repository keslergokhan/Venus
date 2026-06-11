using Microsoft.AspNetCore.Razor.TagHelpers;
using Scriban;
using Scriban.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Venus.Core.Application.HttpRequests.Interfaces;
using Venus.Presentation.Client.Core.HtmlCustomTagParser;

namespace Venus.Presentation.Client.Core.VenusTagHelpers.Base
{
    public abstract class VenusWidgetManagerBase : IVenusWidgetManager
    {
        protected readonly IHtmlCustomTagParserAndRenderFactory CustomTagParserAndRenderFactory;
        protected readonly IVenusHttpContext VenusHttpContext;


        public VenusWidgetManagerBase(IHtmlCustomTagParserAndRenderFactory htmlCustomTagParserAndRenderFactory, IVenusHttpContext venusHttpContext)
        {
            CustomTagParserAndRenderFactory = htmlCustomTagParserAndRenderFactory;
            VenusHttpContext = venusHttpContext;
        }

        public Dictionary<string, object> GetData(string jsonData)
        {
            return JsonSerializer.Deserialize<Dictionary<string, object>>(jsonData);
        }

        public TemplateContext CreateTemplateContext(string jsonData)
        {
            var context = new TemplateContext();
            var model = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonData);
            return CreateTemplateContext(model);
        }

        public TemplateContext CreateTemplateContext(object model)
        {
            var context = new TemplateContext();
            var templateContextJson = JsonSerializer.Serialize(new { Context = VenusHttpContext, Model = model });
            var obj = JsonSerializer.Deserialize<Dictionary<string, object>>(templateContextJson);
            context.PushGlobal(ScriptObject.From(obj));
            return context;
        }


        public async Task<string> RenderWidgetAsync(string widgetTemplate, TemplateContext templateContext)
        {
            var templateHtml = Template.Parse(widgetTemplate);
            return templateHtml.Render(templateContext);
        }

        public virtual Task<string> ExecuteAsync(string templateHtml, string jsonData, Func<TemplateContext, Task> renderBefore = null)
        {
            return ExecuteAsync(templateHtml,GetData(jsonData), renderBefore);
        }

        public virtual async Task<string> ExecuteAsync(string templateHtml, object model, Func<TemplateContext, Task> renderBefore = null)
        {
            var context = CreateTemplateContext(model);
            if (renderBefore!=null)
            {
                await renderBefore.Invoke(context);
            }
            var renderHtmlResult = await RenderWidgetAsync(templateHtml, context);

            if (!string.IsNullOrEmpty(renderHtmlResult))
            {
                renderHtmlResult = await CustomTagParserAndRenderFactory.ParserAsync(renderHtmlResult);
            }

            return renderHtmlResult.ToString();
        }

    }
}
