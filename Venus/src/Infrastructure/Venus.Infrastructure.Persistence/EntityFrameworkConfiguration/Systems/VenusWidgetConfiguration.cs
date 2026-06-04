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
    public class VenusWidgetConfiguration : VenusEntityConfigurationBase<VenusWidget>
    {
        public override void Configure(EntityTypeBuilder<VenusWidget> builder)
        {
            base.Configure(builder);
            builder.HasIndex(x => x.Key).IsUnique();
            builder.Property(x => x.Key).IsRequired();

            builder.Property(x => x.TemplateDataSchema).HasDefaultValue<string>("{}");
            builder.HasMany(x => x.WidgetData)
                .WithOne(x => x.Widget)
                .HasForeignKey(x => x.WidgetId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
        }
    }
}
