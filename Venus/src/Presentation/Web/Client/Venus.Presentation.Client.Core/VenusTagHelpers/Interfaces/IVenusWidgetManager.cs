using Microsoft.AspNetCore.Razor.TagHelpers;
using Scriban;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.HttpRequests.Interfaces;
using Venus.Presentation.Client.Core.VenusTagHelpers.Base;

namespace Venus.Presentation.Client.Core.VenusTagHelpers
{
    public interface IVenusWidgetManager
    {

        public TemplateContext CreateTemplateContext(string jsonData);
        public TemplateContext CreateTemplateContext(object model);
        public Task<string> RenderWidgetAsync(string widgetTemplate, TemplateContext templateContext);
        public Task<string> ExecuteAsync(string templateHtml, object model, Func<TemplateContext, Task> renderBefore = null);
        public Task<string> ExecuteAsync(string templateHtml, string jsonData, Func<TemplateContext, Task> renderBefore = null);
    }
}
