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
    public class VenusPageAboutConfiguration : VenusEntityConfigurationBase<VenusPageAbout>
    {
        public override void Configure(EntityTypeBuilder<VenusPageAbout> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Name)
                .IsRequired(true)
                .HasColumnOrder(1)
                .HasMaxLength(EntityConfigurationConstants.MaxStringLv4);

            builder.Property(x => x.Description)
                .IsRequired(false)
                .HasColumnOrder(2)
                .HasMaxLength(EntityConfigurationConstants.MaxStringLv6);

            builder.Property(x => x.Controller)
                .IsRequired(true)
                .HasColumnOrder(3)
                .HasMaxLength(EntityConfigurationConstants.MaxStringLv3);

            builder.Property(x => x.Action)
                .IsRequired(true)
                .HasColumnOrder(4)
                .HasMaxLength(EntityConfigurationConstants.MaxStringLv3);

            builder.HasOne(x => x.PageType).WithOne(x => x.PageAbout)
                .HasForeignKey<VenusPageAbout>(x => x.PageTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.EntityDataUrl).WithMany(x => x.PageAbouts).HasForeignKey(x => x.EntityDataUrlId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
