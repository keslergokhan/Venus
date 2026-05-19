using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Caching.Base;
using Venus.Core.Application.Caching.Interfaces;
using Venus.Core.Application.Dtos.Systems.Settings;
using Venus.Core.Application.Enums.Systems;
using Venus.Core.Application.Repositories.Interfaces.Systems;

namespace Venus.Core.Application.Caching.Managers
{
    public class VenusConfigurationSettingCacheManager : CacheManagerBase<ReadVenusConfigurationSettingDto,string>, IVenusConfigurationSettingCacheManager
    {
        private readonly IVenusConfigurationSettingRepository _venusConfigurationSettingRepository;
        private readonly IMapper _mapper;

        public VenusConfigurationSettingCacheManager(ICacheService cacheService, IVenusConfigurationSettingRepository venusConfigurationSettingRepository, IMapper mapper) : base(cacheService)
        {
            _venusConfigurationSettingRepository = venusConfigurationSettingRepository;
            _mapper = mapper;
        }

        public override Func<ReadVenusConfigurationSettingDto, string> GetKeyProperty => x => $"{x.Key}";

        public override async Task DataCacheUploadAsync()
        {
            var allData = await _venusConfigurationSettingRepository.GetAllAsync(x=>x.State == (int)EntityStateEnum.Online);
            await base.SetAllAsync(_mapper.Map<List<ReadVenusConfigurationSettingDto>>(allData));
        }

        
    }
}
