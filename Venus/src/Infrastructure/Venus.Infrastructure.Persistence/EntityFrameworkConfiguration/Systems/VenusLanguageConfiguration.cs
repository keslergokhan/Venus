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
    public class VenusLanguageConfiguration : VenusEntityConfigurationBase<VenusLanguage>
    {
        public override void Configure(EntityTypeBuilder<VenusLanguage> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name)
                .IsRequired(true)
                .HasMaxLength(EntityConfigurationConstants.MaxStringLv1)
                .HasColumnOrder(1);

            builder.Property(x => x.CountryCode)
                .IsRequired(true)
                .HasMaxLength(EntityConfigurationConstants.MaxStringLv0)
                .HasColumnOrder(3);

            builder.Property(x => x.Culture)
                .IsRequired(true)
                .HasMaxLength(EntityConfigurationConstants.MaxStringLv0)
                .HasColumnOrder(5);

            builder.Property(x => x.Currency)
                .IsRequired(true)
                .HasColumnOrder(6);

            builder.Property(x => x.Sort)
                .IsRequired(true)
                .HasColumnOrder(8);
        }
    }
}
