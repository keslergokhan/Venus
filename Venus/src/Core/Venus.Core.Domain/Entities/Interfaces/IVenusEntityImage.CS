using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venus.Core.Domain.Entities.Interfaces
{
    public interface IVenusEntityImage
    {
        public string Image { get; set; }
    }

    public interface IEntityMobilImage
    {
        public string ImageMobile { get; set; }
    }
}
