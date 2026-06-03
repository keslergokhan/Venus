using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Domain.Entities.Systems;
using Venus.Infrastructure.Persistence.EntityFrameworkConfiguration.Base;

namespace Venus.Infrastructure.Persistence.EntityFrameworkConfiguration.Systems
{
    public class VenusWidgetDataConfiguration : VenusEntityLanguageConfigurationBase<VenusWidgetData>
    {
        override public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<VenusWidgetData> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Data).HasDefaultValue<string>("{}");
        }
    }
}
