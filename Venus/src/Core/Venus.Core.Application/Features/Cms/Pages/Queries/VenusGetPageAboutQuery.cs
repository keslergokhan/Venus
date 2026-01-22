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
using Venus.Core.Application.Repositories.Interfaces.Cms;
using Venus.Core.Application.Results;
using Venus.Core.Application.Results.Interfaces;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Features.Cms.Pages.Queries
{
    public class VenusGetPageAboutQuery : IRequest<IResultDataControl<List<ReadVenusPageAboutDto>>>
    {
    }

    public class VenusGetPageAboutQueryHandler : IRequestHandler<VenusGetPageAboutQuery, IResultDataControl<List<ReadVenusPageAboutDto>>>
    {
        private readonly IReadVenusPageAboutCmsRepository _venusPageAboutRepository;
        private readonly IReadVenusPageTypeCmsRepository _ff;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public VenusGetPageAboutQueryHandler(IReadVenusPageAboutCmsRepository venusPageAboutRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor, IReadVenusPageTypeCmsRepository ff)
        {
            _venusPageAboutRepository = venusPageAboutRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _ff = ff;
        }

        public async Task<IResultDataControl<List<ReadVenusPageAboutDto>>> Handle(VenusGetPageAboutQuery request, CancellationToken cancellationToken)
        {
            IResultDataControl<List<ReadVenusPageAboutDto>> result = new ResultDataControl<List<ReadVenusPageAboutDto>>();

            try
            {
                List<VenusPageAbout> venusPageAboutList = await this._venusPageAboutRepository.GetPageTypeAndRelations();

                List<ReadVenusPageAboutDto> venusPageAboutDtoList = this._mapper.Map<List<ReadVenusPageAboutDto>>(venusPageAboutList);
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
