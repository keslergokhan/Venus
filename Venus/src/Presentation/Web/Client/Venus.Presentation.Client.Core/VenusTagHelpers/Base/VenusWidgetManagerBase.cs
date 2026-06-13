using Scriban;
using Scriban.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Venus.Core.Application.Enums.Systems;
using Venus.Core.Application.HttpRequests.Interfaces;
using Venus.Presentation.Client.Core.HtmlCustomTagParser;

namespace Venus.Presentation.Client.Core.VenusTagHelpers.Base
{
    public abstract class VenusWidgetManagerBase : IVenusScribanManager
    {
        protected readonly IHtmlCustomTagParserAndRenderFactory CustomTagParserAndRenderFactory;
        protected readonly IVenusHttpContext VenusHttpContext;


        public VenusWidgetManagerBase(IHtmlCustomTagParserAndRenderFactory htmlCustomTagParserAndRenderFactory, IVenusHttpContext venusHttpContext)
        {
            CustomTagParserAndRenderFactory = htmlCustomTagParserAndRenderFactory;
            VenusHttpContext = venusHttpContext;
        }

        public object GetData(string widgetData,WidgetTypeEnum widgetType)
        {
            if (widgetType== WidgetTypeEnum.Custom)
            {
                return JsonSerializer.Deserialize<Dictionary<string, object>>(widgetData);
            }
            else
            {
                return widgetData;
            }
        }

        public TemplateContext CreateTemplateContext(string widgetData,WidgetTypeEnum widgetType)
        {
            var context = new TemplateContext();
            object model = GetData(widgetData,widgetType);
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

        public virtual Task<string> ExecuteAsync(string templateHtml, string widgetData,WidgetTypeEnum widgetType, Func<TemplateContext, Task> renderBefore = null)
        {
            return ExecuteAsync(templateHtml,GetData(widgetData,widgetType),widgetType, renderBefore);
        }

        public virtual async Task<string> ExecuteAsync(string templateHtml, object model, WidgetTypeEnum widgetTyp, Func<TemplateContext, Task> renderBefore = null)
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
