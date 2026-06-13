using HtmlAgilityPack;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Scriban;
using Scriban.Runtime;
using System;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Xml.Linq;
using Venus.Core.Application.Exceptions.Base;
using Venus.Core.Application.HttpRequests.Interfaces;
using Venus.Core.Application.Results.Interfaces;

namespace Venus.Presentation.Client.Core.HtmlCustomTagHelpers.Base
{
    /// <summary>
    /// Venüs sistemine özel dinamik HTML etiketlerinin tanımlanmasını ve
    /// render sürecine katılan bileşenlerin iş mantığının yürütülmesini sağlayan temel sınıftır.<br></br>
    ///
    /// Çalışma prensibi ASP.NET Core TagHelper yapısına benzer.
    /// </summary>
    /// <example>
    /// 
    /// <see cref="VenusHtmlCustomTagNameAttribute"/> ile belirtilen etiketin içerisinde girilmesi beklenen attributes değerlerini temsil edder.
    /// <code>
    /// public class VenusLanguageResourceHtmlCustomTagHelper : VenusHtmlCustomTagHelper
    /// {
    ///     [VenusHtmlCustomTagName("key-data", "")]
    ///     public string Key { get; set; }
    ///
    ///     public VenusLanguageResourceHtmlCustomTagHelper(
    ///         IServiceProvider serviceProvider)
    ///         : base(serviceProvider)
    ///     {
    ///     }
    ///
    ///     public override string HtmlTargetElement => "venus-lang-resource";
    ///
    ///     public override short RenderOrder => 99;
    ///
    ///     protected override async Task&lt;string&gt; GetTemplateAsync()
    ///     {
    ///         return "<div></div>";
    ///     }
    /// }
    /// </code>
    /// 
    /// İmplemente edilen alt sınıflar aracılığı ile özel html etiketleri render edilebilir duruma gelir.
    /// <code>
    ///     <venus-lan-resource key-data="Carousel"></venus-lan-resource>
    /// </code>
    /// </example>
    public abstract class VenusHtmlCustomTagHelper: IVenusHtmlCustomTagHelper
    {
        [VenusHtmlCustomTagNameAttribute("json-data","{}")]
        public string JsonData { get; set; }

        protected readonly IMediator Mediator;
        protected readonly IVenusHttpContext VenusHttpContext;
        private readonly IServiceProvider _serviceProvider;

        public abstract string HtmlTargetElement { get; }
        public abstract short RenderOrder { get; }

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

        protected virtual Task<string> RenderAfterAsync(string htmlResult)
        {
            return Task.FromResult(htmlResult);
        }


        protected abstract Task<string> GetTemplateAsync();

        protected async Task ErrorRender(HtmlNode htmlWidget, string errorCode, string errorMessage)
        {
            var widgetContent = HtmlNode.CreateNode($"<{HtmlTargetElement}-error></{HtmlTargetElement}-error>");
            widgetContent.SetAttributeValue("error-code-data",errorCode);
            widgetContent.SetAttributeValue("error-message-data",errorMessage);
            htmlWidget.AppendChild(widgetContent);
            htmlWidget.RemoveChild(htmlWidget.SelectSingleNode(".//script[@type='application/json']"));
            htmlWidget.Name = "div";
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
                html = await RenderAfterAsync(html);
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

            var content = HtmlNode.CreateNode(html);
            cutomTagNode.AppendChild(content);
            cutomTagNode.Attributes.Remove("key-data");
            cutomTagNode.Attributes.Add("custom-tag-name-data", HtmlTargetElement);
            cutomTagNode.Name = "div";

            return html;
        }

    }
}
