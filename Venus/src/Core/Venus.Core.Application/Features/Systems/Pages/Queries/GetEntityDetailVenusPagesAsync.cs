using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Pages;
using Venus.Core.Application.Features.Interfaces;
using Venus.Core.Application.Repositories.Interfaces.Systems;
using Venus.Core.Application.Results;
using Venus.Core.Application.Results.Interfaces;

namespace Venus.Core.Application.Features.Systems.Pages.Queries
{
    public class GetEntityDetailVenusPagesAsync : IRequest<IResultDataControl<List<ReadVenusPageDto>>>, ILanguageRequest
    {
        public Guid LanguageId { get; set; }
    }

    public class GetEntityDetailVenusPagesHandler : IRequestHandler<GetEntityDetailVenusPagesAsync, IResultDataControl<List<ReadVenusPageDto>>>
    {
        private readonly IVenusPageRepository _venusPageRepository;
        private readonly IMapper _mapper;
        public GetEntityDetailVenusPagesHandler(IVenusPageRepository venusPageRepository, IMapper mapper)
        {
            _venusPageRepository = venusPageRepository;
            _mapper = mapper;
        }
        public async Task<IResultDataControl<List<ReadVenusPageDto>>> Handle(GetEntityDetailVenusPagesAsync request, CancellationToken cancellationToken)
        {
            IResultDataControl<List<ReadVenusPageDto>> result = new ResultDataControl<List<ReadVenusPageDto>>();
            try
            {
                var list = await _venusPageRepository.GetAllEntityDetailPageByEntityNameAsync(request.LanguageId);
                result.SuccessSetData(_mapper.Map<List<ReadVenusPageDto>>(list));
            }
            catch (Exception ex)
            {
                result.Fail(ex);
            }

            return result;
        }
    }
}
