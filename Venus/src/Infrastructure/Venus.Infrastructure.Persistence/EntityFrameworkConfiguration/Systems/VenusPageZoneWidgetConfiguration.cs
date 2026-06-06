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
    public class VenusPageZoneWidgetConfiguration : VenusEntityLanguageConfigurationBase<VenusPageZoneWidget>
    {
        public override void Configure(EntityTypeBuilder<VenusPageZoneWidget> builder)
        {
            base.Configure(builder);

            builder
                .Property(x => x.WidgetData)
                .IsRequired(true)
                .HasDefaultValue<string>("{}");

            builder
                .HasOne(x=>x.Widget)
                .WithMany()
                .HasForeignKey(x=>x.WidgetId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne<VenusPageZone>()
                .WithMany(x=>x.ZoneWidgets)
                .HasForeignKey(x=>x.ZoneId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
