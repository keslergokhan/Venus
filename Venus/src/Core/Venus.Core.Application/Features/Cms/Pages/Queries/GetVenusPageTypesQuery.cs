using MapsterMapper;
using MediatR;
using Venus.Core.Application.Dtos.Systems.Pages;
using Venus.Core.Application.Enums.Systems;
using Venus.Core.Application.Repositories.Interfaces.Systems;
using Venus.Core.Application.Results;
using Venus.Core.Application.Results.Interfaces;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Features.Cms
{
    public class GetVenusPageTypesQuery : IRequest<IResultDataControl<List<ReadVenusPageTypeDto>>>
    {
    }

    public class VenusGetPageTypesQueryHandler : IRequestHandler<GetVenusPageTypesQuery, IResultDataControl<List<ReadVenusPageTypeDto>>>
    {
        private readonly IVenusPageTypeRepository _venusPageTypeRepository;
        private readonly IMapper _mapper;

        public VenusGetPageTypesQueryHandler(IVenusPageTypeRepository venusPageTypeRepository, IMapper mapper)
        {
            _venusPageTypeRepository = venusPageTypeRepository;
            _mapper = mapper;
        }

        public async Task<IResultDataControl<List<ReadVenusPageTypeDto>>> Handle(GetVenusPageTypesQuery request, CancellationToken cancellationToken)
        {
            IResultDataControl<List<ReadVenusPageTypeDto>> result = new ResultDataControl<List<ReadVenusPageTypeDto>>();

            try
            {
                List<VenusPageType> list = await _venusPageTypeRepository.GetPageTypeAndRelations();

                List<ReadVenusPageTypeDto> dtoList = _mapper.Map<List<ReadVenusPageTypeDto>>(list);
                result.SuccessSetData(dtoList);
            }
            catch (Exception ex)
            {
                result.Fail(ex);
            }

            return result;
        }
    }
}
