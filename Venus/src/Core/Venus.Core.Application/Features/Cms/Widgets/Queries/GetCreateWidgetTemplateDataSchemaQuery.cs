using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Results;
using Venus.Core.Application.Results.Interfaces;
using Venus.Core.Application.Services.Interfaces;
using Venus.Core.Application.Services.Models;

namespace Venus.Core.Application.Features.Cms.Widgets.Queries
{
    public class GetCreateWidgetTemplateDataSchemaQueryResponse
    {
        public List<TemplateVariableSchema> TemplateDataSchemaList { get; set; }
    }
   

    public class GetCreateWidgetTemplateDataSchemaQuery : IRequest<IResultDataControl<GetCreateWidgetTemplateDataSchemaQueryResponse>>
    {
        public string Template { get; set; }
    }

    public class GetCreateWidgetTemplateDataSchemaQueryHandler : IRequestHandler<GetCreateWidgetTemplateDataSchemaQuery, IResultDataControl<GetCreateWidgetTemplateDataSchemaQueryResponse>>
    {
        private readonly IHtmlTemplateEngineReview _htmlTemplateEngineReview;
        public GetCreateWidgetTemplateDataSchemaQueryHandler(IHtmlTemplateEngineReview htmlTemplateEngineReview)
        {
            _htmlTemplateEngineReview = htmlTemplateEngineReview;
        }
        public async Task<IResultDataControl<GetCreateWidgetTemplateDataSchemaQueryResponse>> Handle(GetCreateWidgetTemplateDataSchemaQuery request, CancellationToken cancellationToken)
        {
            IResultDataControl<GetCreateWidgetTemplateDataSchemaQueryResponse> result = new ResultDataControl<GetCreateWidgetTemplateDataSchemaQueryResponse>();
            try
            {
                var variables = await _htmlTemplateEngineReview.HtmlTemplateSchemaExtractAsync(request.Template);
                var response = new GetCreateWidgetTemplateDataSchemaQueryResponse
                {
                    TemplateDataSchemaList = variables
                };
                return result.SuccessSetData(response);
            }
            catch (Exception ex)
            {
                result.Fail(ex);
            }
            return result;
        }
    }
}
