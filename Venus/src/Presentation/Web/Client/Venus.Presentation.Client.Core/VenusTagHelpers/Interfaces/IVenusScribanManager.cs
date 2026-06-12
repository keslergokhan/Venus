using Microsoft.AspNetCore.Razor.TagHelpers;
using Scriban;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Enums.Systems;
using Venus.Core.Application.HttpRequests.Interfaces;
using Venus.Presentation.Client.Core.VenusTagHelpers.Base;

namespace Venus.Presentation.Client.Core.VenusTagHelpers
{
    public interface IVenusScribanManager
    {

        public TemplateContext CreateTemplateContext(string jsonData,WidgetTypeEnum widgetType);
        public TemplateContext CreateTemplateContext(object model);
        public Task<string> RenderWidgetAsync(string widgetTemplate, TemplateContext templateContext);
        public Task<string> ExecuteAsync(string templateHtml, object model, WidgetTypeEnum widgetType,Func<TemplateContext, Task> renderBefore = null);
        public Task<string> ExecuteAsync(string templateHtml, string widgetData, WidgetTypeEnum widgetType, Func<TemplateContext, Task> renderBefore = null);
    }
}
