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
    public class VenusUserConfiguration : VenusEntityConfigurationBase<VenusUser>
    {
        public override void Configure(EntityTypeBuilder<VenusUser> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(EntityConfigurationConstants.MaxStringLv4);
            builder.Property(x => x.Surname).IsRequired(true).HasMaxLength(EntityConfigurationConstants.MaxStringLv4);
            builder.Property(x => x.Email).IsRequired(true).HasMaxLength(EntityConfigurationConstants.MaxStringLv4);
            builder.Property(x => x.Password).IsRequired(true).HasMaxLength(EntityConfigurationConstants.MaxStringLv1);
        }
    }
}
