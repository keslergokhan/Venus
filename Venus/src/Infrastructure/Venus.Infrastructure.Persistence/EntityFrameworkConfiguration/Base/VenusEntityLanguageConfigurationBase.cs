using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Domain.Entities.Interfaces;

namespace Venus.Infrastructure.Persistence.EntityFrameworkConfiguration.Base
{
    public abstract class VenusEntityLanguageConfigurationBase<T> : VenusEntityConfigurationBase<T> where T : class, IVenusEntityLanguage
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);
            builder.HasOne(x => x.Language).WithMany().HasForeignKey(x => x.LanguageId);
        }
    }
}
