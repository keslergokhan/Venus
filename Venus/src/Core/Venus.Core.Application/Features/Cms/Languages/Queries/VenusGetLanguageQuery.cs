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
using Venus.Core.Application.Repositories.Interfaces.Cms;
using Venus.Core.Application.Results;
using Venus.Core.Application.Results.Interfaces;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Features.Cms.Languages.Queries
{
    public class VenusGetLanguageQuery : IRequest<IResultDataControl<List<ReadVenusLanguageDto>>>
    {
    }

    public class VenusGetLanguageQueryHandler : IRequestHandler<VenusGetLanguageQuery, IResultDataControl<List<ReadVenusLanguageDto>>>
    {
        private readonly IReadVenusLanguageCmsRepository _readVenusLanguageCmsRepository;
        private readonly IMapper _mapper;

        public VenusGetLanguageQueryHandler(IReadVenusLanguageCmsRepository readVenusLanguageCmsRepository, IMapper mapper)
        {
            _readVenusLanguageCmsRepository = readVenusLanguageCmsRepository;
            _mapper = mapper;
        }

        public async Task<IResultDataControl<List<ReadVenusLanguageDto>>> Handle(VenusGetLanguageQuery request, CancellationToken cancellationToken)
        {
            IResultDataControl<List<ReadVenusLanguageDto>> result = new ResultDataControl<List<ReadVenusLanguageDto>>();
            try
            {
                List<VenusLanguage> languageResult = await this._readVenusLanguageCmsRepository.GetAllAsync(x => x.State == (short)EntityStateEnum.Online);

                result.SetData(this._mapper.Map<List<ReadVenusLanguageDto>>(languageResult.OrderBy(x=>x.Sort)));
            }
            catch (Exception ex)
            {
                result.Fail(ex);
            }

            return result;
        }
    }
}
