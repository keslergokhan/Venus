using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Widget;
using Venus.Core.Application.Repositories.Interfaces.Systems;
using Venus.Core.Application.Results;
using Venus.Core.Application.Results.Interfaces;
using Venus.Core.Application.Services;
using Venus.Core.Application.Services.Interfaces;

namespace Venus.Core.Application.Features.Cms.Widgets.Queries
{


    public class GetWidgetTemplateDataSchemaQuery : IRequest<IResultDataControl<ReadVenusWidgetDto>>
    {
        public Guid WidgetId { get; set; }
    }

    public class GetWidgetTemplateDataSchemaQueryHandler : IRequestHandler<GetWidgetTemplateDataSchemaQuery, IResultDataControl<ReadVenusWidgetDto>>
    {
        private readonly IMapper _mapper;
        private readonly IVenusWidgetRepository _venusWidgetRepository;
        private readonly IHtmlTemplateEngineReview _htmlTemplateEngineReview;

        public GetWidgetTemplateDataSchemaQueryHandler(IMapper mapper, IVenusWidgetRepository venusWidgetRepository, IHtmlTemplateEngineReview htmlTemplateEngineReview)
        {
            _mapper = mapper;
            _venusWidgetRepository = venusWidgetRepository;
            _htmlTemplateEngineReview = htmlTemplateEngineReview;
        }

        public async Task<IResultDataControl<ReadVenusWidgetDto>> Handle(GetWidgetTemplateDataSchemaQuery request, CancellationToken cancellationToken)
        {
            IResultDataControl<ReadVenusWidgetDto> result = new ResultDataControl<ReadVenusWidgetDto>(); 
            try
            {
                var widget = await _venusWidgetRepository.GetByIdAsync(request.WidgetId, cancellationToken);

                var variables = await _htmlTemplateEngineReview.HtmlTemplateSchemaExtractAsync(widget.Template);

                var widgetDto = _mapper.Map<ReadVenusWidgetDto>(widget);
                if (variables?.Count > 0)
                {
                    widgetDto.TemplateDataSchema = JsonSerializer.Serialize(variables);
                }

                return result.SuccessSetData(widgetDto);
            }
            catch (Exception ex)
            {
                result.Fail(ex);
            }
            return result;
        }
    }
}
