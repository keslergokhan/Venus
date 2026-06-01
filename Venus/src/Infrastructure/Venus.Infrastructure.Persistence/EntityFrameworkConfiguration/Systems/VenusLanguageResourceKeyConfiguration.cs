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
    public class VenusLocalizationConfiguration : VenusEntityConfigurationBase<VenusLanguageResourceKey>
    {
        public override void Configure(EntityTypeBuilder<VenusLanguageResourceKey> builder)
        {
            base.Configure(builder);

            builder.HasIndex(x => x.Key).IsUnique();

            builder.Property(x => x.Key).IsRequired();
            builder.Property(x => x.IsHtml).IsRequired().HasDefaultValue<bool>(false);

        }
    }
}
