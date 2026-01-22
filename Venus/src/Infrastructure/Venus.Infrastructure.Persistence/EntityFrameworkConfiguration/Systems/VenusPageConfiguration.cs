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
    public class VenusPageConfiguration : VenusEntityLanguageConfigurationBase<VenusPage>
    {
        public override void Configure(EntityTypeBuilder<VenusPage> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Name)
                .HasMaxLength(EntityConfigurationConstants.MaxStringLv5)
                .IsRequired(true);

            builder.Property(x => x.Description)
                .HasMaxLength(EntityConfigurationConstants.MaxStringLv6)
                .IsRequired(true);

            builder.HasOne(x => x.Url)
                .WithMany(x=>x.Pages)
                .HasForeignKey(x => x.UrlId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);

          
            builder.HasOne(x => x.ParentPage)
                .WithMany(x => x.SubPages)
                .HasForeignKey(x => x.ParentPageId)
                .IsRequired(false).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.ParentPage)
                .WithMany(x => x.SubPages)
                .HasForeignKey(x => x.ParentPageId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
