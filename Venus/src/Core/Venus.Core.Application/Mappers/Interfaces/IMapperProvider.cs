using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Mappings;

namespace Venus.Core.Application.Mappers.Interfaces
{
    public interface IMapperProvider
    {
        public VenusLanguageMapper LanguageMapper { get; }
        public VenusLocalizationMapper LocalizationMapper { get; }
        public VenusPageMapper VenusPageMapper { get; }
        public VenusUrlMapping VenusUrlMapping { get; }
        public VenusUserMapper VenusUserMapper { get; }
        public VenusPageTypeMapper VenusPageTypeMapper { get; }
        public VenusPageAboutMapper VenusPageAboutMapper { get;}
        public VenusEntityDataUrlMapper VenusEntityDataUrlMapper { get;}
    }
}
