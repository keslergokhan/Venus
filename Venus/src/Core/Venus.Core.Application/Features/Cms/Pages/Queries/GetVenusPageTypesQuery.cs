using MapsterMapper;
using MediatR;
using Venus.Core.Application.Dtos.Systems.Pages;
using Venus.Core.Application.Enums.Systems;
using Venus.Core.Application.Repositories.Interfaces.Cms;
using Venus.Core.Application.Results;
using Venus.Core.Application.Results.Interfaces;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Features.Cms.Pages.Queries
{
    public class GetVenusPageTypesQuery : IRequest<IResultDataControl<List<ReadVenusPageTypeDto>>>
    {
    }

    public class VenusGetPageTypesQueryHandler : IRequestHandler<GetVenusPageTypesQuery, IResultDataControl<List<ReadVenusPageTypeDto>>>
    {
        private readonly IReadVenusPageTypeCmsRepository _venusPageTypeRepository;
        private readonly IMapper _mapper;

        public VenusGetPageTypesQueryHandler(IReadVenusPageTypeCmsRepository venusPageTypeRepository, IMapper mapper)
        {
            _venusPageTypeRepository = venusPageTypeRepository;
            _mapper = mapper;
        }

        public async Task<IResultDataControl<List<ReadVenusPageTypeDto>>> Handle(GetVenusPageTypesQuery request, CancellationToken cancellationToken)
        {
            IResultDataControl<List<ReadVenusPageTypeDto>> result = new ResultDataControl<List<ReadVenusPageTypeDto>>();

            try
            {
                List<VenusPageType> list = await this._venusPageTypeRepository.GetPageTypeAndRelations();

                List<ReadVenusPageTypeDto> dtoList = this._mapper.Map<List<ReadVenusPageTypeDto>>(list);
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
