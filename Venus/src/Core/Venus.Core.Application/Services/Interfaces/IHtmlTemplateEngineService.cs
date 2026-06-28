using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.HttpRequests.Interfaces;
using Venus.Core.Application.Services.Models;

namespace Venus.Core.Application.Services.Interfaces
{
    public interface IHtmlTemplateEngineReview
    {
        public Task<List<ScriptVisitModel>> HtmlTemplateSchemaExtractAsync(string html);
    }
}
