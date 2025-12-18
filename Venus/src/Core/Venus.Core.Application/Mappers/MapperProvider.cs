using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Mappers.Interfaces;
using Venus.Core.Application.Mappings;

namespace Venus.Core.Application.Mappers
{
    public class MapperProvider : IMapperProvider
    {
        public VenusLanguageMapper LanguageMapper { get; private set; }
        public VenusLocalizationMapper LocalizationMapper { get; private set; }
        public VenusPageMapper VenusPageMapper { get; private set; }
        public VenusUrlMapping VenusUrlMapping { get; private set; }
        public VenusUserMapper VenusUserMapper { get; private set; }

        public VenusPageTypeMapper VenusPageTypeMapper { get; private set; }

        public VenusPageAboutMapper VenusPageAboutMapper { get; private set; }
        public VenusEntityDataUrlMapper VenusEntityDataUrlMapper { get; private set; }

        public MapperProvider(VenusUserMapper venusUserMapper, VenusUrlMapping venusUrlMapping, VenusPageMapper venusPageMapper, VenusLocalizationMapper localizationMapper, VenusLanguageMapper languageMapper, VenusPageTypeMapper venusPageTypeMapper, VenusPageAboutMapper venusPageAboutMapper, VenusEntityDataUrlMapper venusEntityDataUrlMapper)
        {
            VenusUserMapper = venusUserMapper;
            VenusUrlMapping = venusUrlMapping;
            VenusPageMapper = venusPageMapper;
            LocalizationMapper = localizationMapper;
            LanguageMapper = languageMapper;
            VenusPageTypeMapper = venusPageTypeMapper;
            VenusPageAboutMapper = venusPageAboutMapper;
            VenusEntityDataUrlMapper = venusEntityDataUrlMapper;
        }
    }
}
