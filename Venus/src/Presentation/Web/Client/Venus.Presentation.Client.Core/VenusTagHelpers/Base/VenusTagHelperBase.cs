using MediatR;
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
using Venus.Core.Application.Dtos.Systems.Widget;
using Venus.Core.Application.Exceptions.Base;
using Venus.Core.Application.Features.Systems.Widget.Queries;
using Venus.Core.Application.HttpRequests.Interfaces;
using Venus.Core.Application.Results.Interfaces;
using Venus.Presentation.Client.Core.HtmlCustomTagParser;

namespace Venus.Presentation.Client.Core.VenusTagHelpers.Base
{
    public abstract class VenusTagHelperBase : TagHelper
    {
        protected readonly IMediator Mediator;
        protected readonly IVenusHttpContext VenusHttpContext;
        protected readonly IHtmlCustomTagParserAndRenderFactory CustomTagParserAndRenderFactory;
        protected IServiceProvider ServiceProvider;
        protected IVenusWidgetManager VenusWidgetManager;

        public VenusTagHelperBase(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            Mediator = ServiceProvider.GetRequiredService<IMediator>();
            CustomTagParserAndRenderFactory = ServiceProvider.GetRequiredService<IHtmlCustomTagParserAndRenderFactory>();
            VenusHttpContext = ServiceProvider.GetRequiredService<IVenusHttpContext>();
            VenusWidgetManager = ServiceProvider.GetRequiredService<IVenusWidgetManager>();
        }

        public virtual Dictionary<string, object> GetData()
        {
            return null;
        }

        protected abstract Task<string> GetTemplateAsync();

        public virtual TemplateContext TemplateContext()
        {
            return VenusWidgetManager.CreateTemplateContext(GetData());
        }

        public abstract Task RenderBeforeAsync(TagHelperContext context, TagHelperOutput output,TemplateContext templateContext);

        public virtual async Task RenderWidgetAsync(TagHelperContext context, TagHelperOutput output)
        {
            try
            {
                Func<TemplateContext,Task> before = (tempalteContext) =>
                {
                    return RenderBeforeAsync(context, output, tempalteContext);
                };

                var renderedHtml = await VenusWidgetManager.ExecuteAsync(await GetTemplateAsync(), GetData(), before);
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

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await RenderWidgetAsync(context, output);
        }


        public async Task ErrorProcessAsync(TagHelperContext context, TagHelperOutput output, string errorCode,string errorMessage)
        {
            var container = new TagBuilder("venus-widget-error");
            container.Attributes.Add("error-data", errorCode);
            container.Attributes.Add("error-message", errorMessage);
            output.Content.SetHtmlContent(container);
        }
    }
}
