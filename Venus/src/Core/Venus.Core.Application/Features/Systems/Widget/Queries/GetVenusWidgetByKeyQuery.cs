using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Widget;
using Venus.Core.Application.Exceptions.Systems;
using Venus.Core.Application.Features.Interfaces;
using Venus.Core.Application.Repositories.Interfaces.Systems;
using Venus.Core.Application.Results;
using Venus.Core.Application.Results.Interfaces;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Features.Systems.Widget.Queries
{
    public class GetVenusWidgetByKeyQuery : IRequest<IResultDataControl<ReadVenusWidgetDto>>
    {
        public string Key { get; set; }
    }

    public class GetVenusWidgetByKeyQueryHandler : IRequestHandler<GetVenusWidgetByKeyQuery, IResultDataControl<ReadVenusWidgetDto>>
    {
        private readonly IVenusWidgetRepository _venusWidgetRepository;
        private readonly IMapper _mapper;

        public GetVenusWidgetByKeyQueryHandler(IVenusWidgetRepository venusWidgetRepository, IMapper mapper)
        {
            _venusWidgetRepository = venusWidgetRepository;
            _mapper = mapper;
        }

        public async Task<IResultDataControl<ReadVenusWidgetDto>> Handle(GetVenusWidgetByKeyQuery request, CancellationToken cancellationToken)
        {
            var response = new ResultDataControl<ReadVenusWidgetDto>();

            try
            {
                var widget = await _venusWidgetRepository.GetWidgetAndByKeyAsync(request.Key);

                if (widget == null)
                    throw new VenusNotFoundWidgetSystemException(request.Key);

                var widgetDto = _mapper.Map<ReadVenusWidgetDto>(widget);

                

                response.SetData(widgetDto);
            }
            catch (Exception ex)
            {
                response.Fail(ex);
            }

            return response;
        }
    }
}
