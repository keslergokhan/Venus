using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Domain.Entities.Base;
using Venus.Core.Domain.Entities.Systems;
using Venus.Infrastructure.Persistence.Constants;
using Venus.Infrastructure.Persistence.EntityFrameworkConfiguration.Base;

namespace Venus.Infrastructure.Persistence.EntityFrameworkConfiguration.Systems
{
    public class VenusEntityDataUrlConfiguration : VenusEntityConfigurationBase<VenusPageEntity>
    {
        public override void Configure(EntityTypeBuilder<VenusPageEntity> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.EntityClassType)
                .HasMaxLength(EntityConfigurationConstants.MaxStringLv6)
                .IsRequired(true)
                .HasColumnOrder(1);

            builder.Property(x => x.EntityName)
                .HasMaxLength(EntityConfigurationConstants.MaxStringLv6)
                .IsRequired(true)
                .HasColumnOrder(3);
        }
    }
}
