using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Widget;
using Venus.Core.Application.Enums.Systems;
using Venus.Core.Application.Repositories.Interfaces;
using Venus.Core.Application.Repositories.Interfaces.Systems;
using Venus.Core.Application.Results;
using Venus.Core.Application.Results.Interfaces;

namespace Venus.Core.Application.Features.Cms.Widgets.Commands
{
    public class UpdateWidgetCommand : IRequest<IResultDataControl<ReadVenusWidgetDto>>
    {
        public Guid Id { get; set; }
        public string Template { get; set; }
    }

    public class UpdateWidgetCommandHandler : IRequestHandler<UpdateWidgetCommand, IResultDataControl<ReadVenusWidgetDto>>
    {
        private readonly IVenusWidgetRepository _venusWidgetRepository;
        private readonly IVenusUnitOfWork _venusUnitOfWork;
        private readonly IMapper _mapper;

        public UpdateWidgetCommandHandler(IVenusWidgetRepository venusWidgetRepository, IVenusUnitOfWork venusUnitOfWork, IMapper mapper)
        {
            _venusWidgetRepository = venusWidgetRepository;
            _venusUnitOfWork = venusUnitOfWork;
            _mapper = mapper;
        }

        public async Task<IResultDataControl<ReadVenusWidgetDto>> Handle(UpdateWidgetCommand request, CancellationToken cancellationToken)
        {
            var result = new ResultDataControl<ReadVenusWidgetDto>();

            try
            {
                var widget = await _venusWidgetRepository.GetByIdTrackingAsync(request.Id,cancellationToken);

                widget.Template = request.Template;
                widget.ModifiedDate = DateTime.Now;

                await _venusUnitOfWork.SaveChangesAsync(cancellationToken);

                var widgetDto = _mapper.Map<ReadVenusWidgetDto>(widget);
                result.SuccessSetData(widgetDto);
            }
            catch (Exception ex)
            {
                result.Fail(ex);
            }

            return result;
        }
    }
}
