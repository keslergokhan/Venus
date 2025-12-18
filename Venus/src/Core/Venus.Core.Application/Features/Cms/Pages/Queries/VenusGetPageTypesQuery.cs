using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Pages;
using Venus.Core.Application.Enums.Systems;
using Venus.Core.Application.Mappers.Interfaces;
using Venus.Core.Application.Repositories.Interfaces.Cms;
using Venus.Core.Application.Results;
using Venus.Core.Application.Results.Interfaces;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Features.Cms.Pages.Queries
{
    public class VenusGetPageTypesQuery : IRequest<IResultDataControl<List<ReadVenusPageTypeDto>>>
    {
    }

    public class VenusGetPageTypesQueryHandler : IRequestHandler<VenusGetPageTypesQuery, IResultDataControl<List<ReadVenusPageTypeDto>>>
    {
        private readonly IVenusPageTypeRepository _venusPageTypeRepository;
        private readonly IMapperProvider _mapperProvider;

        public VenusGetPageTypesQueryHandler(IVenusPageTypeRepository venusPageTypeRepository, IMapperProvider mapperProvider)
        {
            _venusPageTypeRepository = venusPageTypeRepository;
            _mapperProvider = mapperProvider;
        }

        public async Task<IResultDataControl<List<ReadVenusPageTypeDto>>> Handle(VenusGetPageTypesQuery request, CancellationToken cancellationToken)
        {
            IResultDataControl<List<ReadVenusPageTypeDto>> result = new ResultDataControl<List<ReadVenusPageTypeDto>>();

            try
            {
                List<VenusPageType> list = await this._venusPageTypeRepository.GetAllAsync(x => x.State == (int)EntityStateEnum.Online);

                List<ReadVenusPageTypeDto> dtoList = list.Select(x => this._mapperProvider.VenusPageTypeMapper.ToDto(x)).ToList();
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
