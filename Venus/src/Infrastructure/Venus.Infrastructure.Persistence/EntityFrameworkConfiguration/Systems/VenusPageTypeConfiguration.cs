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
    public class VenusPageTypeConfiguration : VenusEntityConfigurationBase<VenusPageType>
    {
        public override void Configure(EntityTypeBuilder<VenusPageType> builder)
        {
            base.Configure(builder);
            
            builder.Property(x => x.InterfaceClassType)
                .HasMaxLength(250)
                .IsRequired(true);

            builder.Property(x => x.Title).IsRequired(true).HasMaxLength(250);
        }
    }
}
