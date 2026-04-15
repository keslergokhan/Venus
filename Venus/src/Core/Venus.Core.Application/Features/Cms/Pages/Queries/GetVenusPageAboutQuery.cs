using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Pages;
using Venus.Core.Application.Enums.Systems;
using Venus.Core.Application.Repositories.Interfaces.Systems;
using Venus.Core.Application.Results;
using Venus.Core.Application.Results.Interfaces;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Features.Cms
{
    public class GetVenusPageAboutQuery : IRequest<IResultDataControl<List<ReadVenusPageAboutDto>>>
    {
    }

    public class VenusGetPageAboutQueryHandler : IRequestHandler<GetVenusPageAboutQuery, IResultDataControl<List<ReadVenusPageAboutDto>>>
    {
        private readonly IVenusPageAboutRepository _venusPageAboutRepository;
        private readonly IMapper _mapper;

        public VenusGetPageAboutQueryHandler(IVenusPageAboutRepository venusPageAboutRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _venusPageAboutRepository = venusPageAboutRepository;
            _mapper = mapper;
        }

        public async Task<IResultDataControl<List<ReadVenusPageAboutDto>>> Handle(GetVenusPageAboutQuery request, CancellationToken cancellationToken)
        {
            IResultDataControl<List<ReadVenusPageAboutDto>> result = new ResultDataControl<List<ReadVenusPageAboutDto>>();

            try
            {
                List<VenusPageAbout> venusPageAboutList = await _venusPageAboutRepository.GetPageTypeAndRelations();

                List<ReadVenusPageAboutDto> venusPageAboutDtoList = _mapper.Map<List<ReadVenusPageAboutDto>>(venusPageAboutList);
                result.SuccessSetData(venusPageAboutDtoList);
            }
            catch (Exception ex)
            {
                result.Fail(ex); 
            }

            return result;
        }
    }
}
