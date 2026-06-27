using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.HttpRequests.Interfaces;

namespace Venus.Core.Application.Services.Interfaces
{
    public interface IHtmlTemplateEngineReview
    {
        public Task HtmlTemplateSchemaExtractAsync(string html);
    }
}
