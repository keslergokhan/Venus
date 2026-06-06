using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.PageZone;
using Venus.Core.Application.Exceptions.Systems;
using Venus.Core.Application.Features.Interfaces;
using Venus.Core.Application.Repositories.Interfaces.Systems;
using Venus.Core.Application.Results;
using Venus.Core.Application.Results.Interfaces;

namespace Venus.Core.Application.Features.Systems.Page.Queries
{
    public class GetVenusPageZoneAndWidgetsByPageIdAndKeyQuery : IRequest<IResultDataControl<ReadVenusPageZoneDto>>, ILanguageRequest
    {
        public Guid PageId { get; set; }
        public string Key { get; set; }
        public Guid LanguageId { get; set; }
    }

    public class GetVenusPageZoneAndWidgetsByPageIdAndKeyQueryHandler : IRequestHandler<GetVenusPageZoneAndWidgetsByPageIdAndKeyQuery, IResultDataControl<ReadVenusPageZoneDto>>
    {
        private readonly IVenusPageZoneRepository _venusPageZoneRepository;
        private readonly IMapper _mapper;

        public GetVenusPageZoneAndWidgetsByPageIdAndKeyQueryHandler(IVenusPageZoneRepository venusPageZoneRepository, IMapper mapper)
        {
            _venusPageZoneRepository = venusPageZoneRepository;
            _mapper = mapper;
        }

        public async Task<IResultDataControl<ReadVenusPageZoneDto>> Handle(GetVenusPageZoneAndWidgetsByPageIdAndKeyQuery request, CancellationToken cancellationToken)
        {
            var result = new ResultDataControl<ReadVenusPageZoneDto>();
            try
            {
                var venusPage = await _venusPageZoneRepository.GetPageZoneAndWidgetsByPageIdAndKeyAsync(request.PageId, request.Key,request.LanguageId);

                if (venusPage == null)
                    throw new VenusNotFoundPageZoneSystemException(request.Key);

                result.SuccessSetData(_mapper.Map<ReadVenusPageZoneDto>(venusPage));
            }
            catch (Exception ex)
            {
                result.Fail(ex);
            }
            return result;
        }
    }
}
