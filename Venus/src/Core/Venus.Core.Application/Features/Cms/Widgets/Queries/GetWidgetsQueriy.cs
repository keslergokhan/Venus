using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Widget;
using Venus.Core.Application.Enums.Systems;
using Venus.Core.Application.Features.Interfaces;
using Venus.Core.Application.Repositories.Interfaces.Systems;
using Venus.Core.Application.Results;
using Venus.Core.Application.Results.Interfaces;

namespace Venus.Core.Application.Features.Cms.Queries
{
    public class GetWidgetsQueriy : IRequest<IResultDataControl<List<ReadVenusWidgetDto>>>
    {
    }

    public class GetWidgetsQueriyHandler : IRequestHandler<GetWidgetsQueriy, IResultDataControl<List<ReadVenusWidgetDto>>>
    {
        private readonly IVenusWidgetRepository _widgetRepository;
        private readonly IMapper _mapper;

        public GetWidgetsQueriyHandler(IVenusWidgetRepository widgetRepository, IMapper mapper)
        {
            _widgetRepository = widgetRepository;
            _mapper = mapper;
        }

        public async Task<IResultDataControl<List<ReadVenusWidgetDto>>> Handle(GetWidgetsQueriy request, CancellationToken cancellationToken)
        {
            IResultDataControl<List<ReadVenusWidgetDto>> result = new ResultDataControl<List<ReadVenusWidgetDto>>();
            try
            {
                var getAllResult = await _widgetRepository.GetAllAsync(x=>x.State == (int)EntityStateEnum.Online);
                result.SuccessSetData(_mapper.Map<List<ReadVenusWidgetDto>>(getAllResult).OrderBy(x=>x.Key).ToList());
            }
            catch (Exception ex)
            {
                result.Fail(ex);
            }

            return result;
        }
    }
}
