using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Languages;
using Venus.Core.Application.Enums.Systems;
using Venus.Core.Application.Repositories.Interfaces.Systems;
using Venus.Core.Application.Results;
using Venus.Core.Application.Results.Interfaces;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Features.Cms
{
    public class GetVenusLanguageQuery : IRequest<IResultDataControl<List<ReadVenusLanguageDto>>>
    {
    }

    public class VenusGetLanguageQueryHandler : IRequestHandler<GetVenusLanguageQuery, IResultDataControl<List<ReadVenusLanguageDto>>>
    {
        private readonly IVenusLanguageRepository _venusLanguageCmsRepository;
        private readonly IMapper _mapper;

        public VenusGetLanguageQueryHandler(IVenusLanguageRepository venusLanguageCmsRepository, IMapper mapper)
        {
            _venusLanguageCmsRepository = venusLanguageCmsRepository;
            _mapper = mapper;
        }

        public async Task<IResultDataControl<List<ReadVenusLanguageDto>>> Handle(GetVenusLanguageQuery request, CancellationToken cancellationToken)
        {
            IResultDataControl<List<ReadVenusLanguageDto>> result = new ResultDataControl<List<ReadVenusLanguageDto>>();
            try
            {
                List<VenusLanguage> languageResult = await _venusLanguageCmsRepository.GetAllAsync(x => x.State == (short)EntityStateEnum.Online);

                result.SetData(_mapper.Map<List<ReadVenusLanguageDto>>(languageResult.OrderBy(x=>x.Sort)));
            }
            catch (Exception ex)
            {
                result.Fail(ex);
            }

            return result;
        }
    }
}
