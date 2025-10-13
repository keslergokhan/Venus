using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venus.Infrastructure.Persistence.Constants
{
    public class EntityConfigurationConstants
    {
        #region StringLength
        public const byte MaxStringLv0 = 10;
        public const byte MaxStringLv1 = 25;
        public const byte MaxStringLv2 = 50;
        public const byte MaxStringLv3 = 100;
        public const short MaxStringLv4 = 200;
        public const short MaxStringLv5 = 300;
        public const short MaxStringLv6 = 500;
        public const short MaxStringLv7 = 1000;

        public const byte MinStringLv1 = 1;
        public const byte MinStringLv2 = 2;
        public const byte MinStringLv3 = 3;
        public const byte MinStringLv4 = 5;
        #endregion StringLength End


        #region DisplayName
        public const string DisplayTitle = "Başlık";
        public const string DisplayName = "Ad";
        public const string DisplayDescription = "Açıklama";
        #endregion DisplayName End
    }
}
