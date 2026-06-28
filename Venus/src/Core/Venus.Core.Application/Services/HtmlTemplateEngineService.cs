using Scriban;
using Scriban.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using Venus.Core.Application.Exceptions.Cms;
using Venus.Core.Application.HttpRequests;
using Venus.Core.Application.HttpRequests.Interfaces;
using Venus.Core.Application.Services.Interfaces;
using Venus.Core.Application.Services.Models;

namespace Venus.Core.Application.Services
{
    public class HtmlTemplateEngineService : IHtmlTemplateEngineReview
    {
        private readonly CustomScriptVisitor _customScript;

        public HtmlTemplateEngineService(CustomScriptVisitor customScript)
        {
            _customScript = customScript;
        }

        public async Task<List<ScriptVisitModel>> HtmlTemplateSchemaExtractAsync(string html)
        {
            try
            {
                var template = Template.Parse(html);
                CustomScriptVisitor script = new CustomScriptVisitor();
                script.Visit(template.Page);
                return script.Variables;
            }
            catch (Exception ex)
            {
                throw new VenusCmsHtmlTemplateSchemaException("Tasarım oluşturulurken teknik bir problem oluştu",ex);
            }
        }
    }
}
