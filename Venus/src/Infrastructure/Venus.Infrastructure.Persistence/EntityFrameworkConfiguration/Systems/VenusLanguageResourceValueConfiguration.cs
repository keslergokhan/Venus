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
    public class VenusLanguageResourceValueConfiguration : VenusEntityConfigurationBase<VenusLanguageResourceValue>
    {
        public override void Configure(EntityTypeBuilder<VenusLanguageResourceValue> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.ResourceKey)
                .WithMany(x => x.ResourceValue)
                .HasForeignKey(x => x.ResourceKeyId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
