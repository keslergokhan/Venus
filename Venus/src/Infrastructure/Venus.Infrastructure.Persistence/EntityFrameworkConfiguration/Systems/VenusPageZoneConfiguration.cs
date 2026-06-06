using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Domain.Entities.Systems;
using Venus.Infrastructure.Persistence.Constants;
using Venus.Infrastructure.Persistence.EntityFrameworkConfiguration.Base;

namespace Venus.Infrastructure.Persistence.EntityFrameworkConfiguration.Systems
{
    public class VenusPageZoneConfiguration : VenusEntityConfigurationBase<Core.Domain.Entities.Systems.VenusPageZone>
    {
        public override void Configure(EntityTypeBuilder<VenusPageZone> builder)
        {
            base.Configure(builder);

            builder.HasIndex(x => x.Key).IsUnique();
            builder.Property(x => x.Key).HasMaxLength(EntityConfigurationConstants.MaxStringLv4).IsRequired();

            builder.HasOne<VenusPage>()
                .WithMany(x=>x.VenusPageZones)
                .HasForeignKey(x=>x.PageId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
