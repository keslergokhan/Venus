using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Localizations;
using Venus.Core.Application.Repositories.Interfaces.Systems;
using Venus.Core.Application.Results;
using Venus.Core.Application.Results.Interfaces;

namespace Venus.Core.Application.Features.Cms.Queries
{
    public class GetVenusLanguageResourceQueriy : IRequest<IResultDataControl<List<ReadVenusLanguageResourceKeyDto>>>
    {
    }

    public class GetVenusLanguageResourceHandler : IRequestHandler<GetVenusLanguageResourceQueriy, IResultDataControl<List<ReadVenusLanguageResourceKeyDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IVenusLanguageResourceKeyRepository _venusLanguageResourceKeyRepository;

        public GetVenusLanguageResourceHandler(IMapper mapper, IVenusLanguageResourceKeyRepository venusLanguageResourceKeyRepository)
        {
            _mapper = mapper;
            _venusLanguageResourceKeyRepository = venusLanguageResourceKeyRepository;
        }

        public async Task<IResultDataControl<List<ReadVenusLanguageResourceKeyDto>>> Handle(GetVenusLanguageResourceQueriy request, CancellationToken cancellationToken)
        {
            IResultDataControl<List<ReadVenusLanguageResourceKeyDto>> result = new ResultDataControl<List<ReadVenusLanguageResourceKeyDto>>();
            try
            {
                var languageResource = await _venusLanguageResourceKeyRepository.GetLanguageResourceAndValueAsync();

                result.SuccessSetData(_mapper.Map<List<ReadVenusLanguageResourceKeyDto>>(languageResource));
            }
            catch (Exception ex)
            {
                result.Fail(ex);
            }
            return result;
        }
    }
}
