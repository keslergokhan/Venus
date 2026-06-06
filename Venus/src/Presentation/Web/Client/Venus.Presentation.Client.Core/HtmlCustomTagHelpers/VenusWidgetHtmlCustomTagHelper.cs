using HtmlAgilityPack;
using MediatR;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Scriban;
using Scriban.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Widget;
using Venus.Core.Application.Features.Systems.Widget.Queries;
using Venus.Core.Application.Results.Interfaces;
using Venus.Presentation.Client.Core.HtmlCustomTagHelpers.Base;

namespace Venus.Presentation.Client.Core.HtmlCustomTagHelpers
{
    public class VenusWidgetHtmlCustomTagHelper : VenusHtmlCustomTagHelper, IVenusHtmlCustomTagHelper
    {
        [VenusHtmlCustomTagNameAttribute("key-data","")]
        public string Key { get; set; }
        public override string HtmlTargetElement => "venus-widget";

        public VenusWidgetHtmlCustomTagHelper(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        protected override async Task<string> GetTemplateAsync()
        {
            IResultDataControl<ReadVenusWidgetDto> result = await Mediator.Send(new GetVenusWidgetByKeyQuery()
            {
                Key = Key,
            });

            if (!result.IsSuccess)
                throw result.Exception;

            return result.Data.Template;
        }

        protected override async Task<string> RenderAfterAsync(string htmlResult)
        {
            var content = HtmlNode.CreateNode(htmlResult);

            var childs = content.SelectNodes($"//{HtmlTargetElement}");
            if (childs==null)
                return htmlResult;

            bool isChild = false;
            foreach (var childItem in childs)
            {
                var keyAttr = childItem.GetAttributeValue("key-data", null);
                if (keyAttr == Key)
                {
                    isChild = true;
                    await ErrorRender(childItem, "AGAIN_ERROR", "İç içe widget");
                    childItem.Name = "div";
                    childItem.Attributes.Add("widget-data", HtmlTargetElement);
                }
            }

            if (isChild)
                return content.OuterHtml;
            else
                return htmlResult;
        }
    }
}
