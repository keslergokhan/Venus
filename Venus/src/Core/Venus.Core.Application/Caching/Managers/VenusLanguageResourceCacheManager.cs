using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Caching.Base;
using Venus.Core.Application.Caching.Interfaces;
using Venus.Core.Application.Dtos.Systems.Localizations;
using Venus.Core.Application.Repositories.Interfaces.Systems;

namespace Venus.Core.Application.Caching.Managers
{
    public class VenusLanguageResourceCacheManager : CacheManagerBase<ReadVenusLanguageResourceKeyDto, string>, IVenusLanguageResourceCacheManager
    {
        private readonly IVenusLanguageResourceKeyRepository _venusLanguageResourceKeyRepository;
        private readonly IMapper _mapper;
        public VenusLanguageResourceCacheManager(ICacheService cacheService, IVenusLanguageResourceKeyRepository venusLanguageResourceKeyRepository, IMapper mapper) : base(cacheService)
        {
            _venusLanguageResourceKeyRepository = venusLanguageResourceKeyRepository;
            _mapper = mapper;
        }

        public override Func<ReadVenusLanguageResourceKeyDto, string> GetKeyProperty => x => x.Key;

        public override async Task DataCacheUploadAsync()
        {
            var data = await _venusLanguageResourceKeyRepository.GetLanguageResourceAndValueAsync();
            await base.SetAllAsync(_mapper.Map<List<ReadVenusLanguageResourceKeyDto>>(data));
        }
    }
}
