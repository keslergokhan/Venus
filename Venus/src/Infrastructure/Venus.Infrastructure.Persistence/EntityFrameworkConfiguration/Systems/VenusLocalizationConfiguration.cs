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
    public class VenusLocalizationConfiguration : VenusEntityConfigurationBase<VenusLocalization>
    {
        public override void Configure(EntityTypeBuilder<VenusLocalization> builder)
        {
            base.Configure(builder);

            builder.HasIndex(x => x.Key).IsUnique();

            builder.Property(x => x.Key)
                .IsRequired()
                .HasMaxLength(EntityConfigurationConstants.MaxStringLv5);

            builder.Property(x => x.DefaultValue).IsRequired();

            builder.Property(x => x.Value).IsRequired(false);

            builder.HasOne(x => x.Language)
                .WithMany()
                .HasForeignKey(x => x.LanguageId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
        }
    }
}
