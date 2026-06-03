using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Caching.Interfaces;
using Venus.Core.Application.Dtos.Systems.Localizations;
using Venus.Core.Application.Dtos.Systems.Settings;
using Venus.Core.Application.Results;
using Venus.Core.Application.Results.Interfaces;

namespace Venus.Core.Application.Features.Cms.Queries
{
    public class GetConfigurationSettingQuery : IRequest<IResultDataControl<List<ReadVenusConfigurationSettingDto>>>
    {
        public bool Hidden { get; set; }
    }

    public class GetConfigurationSettingQueryHandler : IRequestHandler<GetConfigurationSettingQuery, IResultDataControl<List<ReadVenusConfigurationSettingDto>>>
    {
        private readonly IVenusConfigurationSettingCacheManager _venusConfigurationSettingCacheManager;

        public GetConfigurationSettingQueryHandler(IVenusConfigurationSettingCacheManager venusConfigurationSettingCacheManager)
        {
            _venusConfigurationSettingCacheManager = venusConfigurationSettingCacheManager;
        }

        public async Task<IResultDataControl<List<ReadVenusConfigurationSettingDto>>> Handle(GetConfigurationSettingQuery request, CancellationToken cancellationToken)
        {
            IResultDataControl<List<ReadVenusConfigurationSettingDto>> result = new ResultDataControl<List<ReadVenusConfigurationSettingDto>>();
            try
            {
                var data = await _venusConfigurationSettingCacheManager.GetAllAsync();
                result.SuccessSetData(data.Where(x=>x.Hidden == request.Hidden).ToList());
            }
            catch (Exception ex)
            {
                result.Fail(ex);
            }
            return result;
        }
    }
}
