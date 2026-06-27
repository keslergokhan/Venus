using Scriban;
using Scriban.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using Venus.Core.Application.HttpRequests;
using Venus.Core.Application.HttpRequests.Interfaces;
using Venus.Core.Application.Services.Interfaces;

namespace Venus.Core.Application.Services
{
    public class HtmlTemplateEngineService : IHtmlTemplateEngineReview
    {
        public async Task HtmlTemplateSchemaExtractAsync(string html)
        {
            var fff = $$$"""
                {{ field name:"product.name" type:"text" label:"bu bir deneme" }}
                {{ product.name }}  

                {{ product.price }}
                {{ if product.stock > 0 }}
                    {{ product.name }}
                {{ end }}
            """;

            var template = Template.Parse(fff);

            CustomScriptVisitor test = new CustomScriptVisitor();
            test.Visit(template.Page);

            foreach (var item in test.Variables)
            {
                var sdfsd = item;
            }

        }
    }
}
