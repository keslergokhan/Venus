using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Domain.Entities.Systems;
using Venus.Infrastructure.Persistence.EntityFrameworkConfiguration.Base;

namespace Venus.Infrastructure.Persistence.EntityFrameworkConfiguration.Systems
{
    public class VenusConfigurationSettingConfiguration : VenusEntityConfigurationBase<VenusConfigurationSetting>
    {
        public override void Configure(EntityTypeBuilder<VenusConfigurationSetting> builder)
        {
            base.Configure(builder);
            builder.HasIndex(x => x.Key).IsUnique();
            builder.Property(x => x.Key).IsUnicode().IsRequired();
            builder.Property(x => x.UpdatePermission).HasDefaultValue(true);
            builder.Property(x=>x.Hidden).HasDefaultValue(false);
        }
    }
}
